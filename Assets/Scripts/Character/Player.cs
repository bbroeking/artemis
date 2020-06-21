using UnityEngine;
using System.Collections.Generic;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public enum Soul {
    gravity,
    poison
}
public class Player : Character
{
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private Animator anim;
    
    [SerializeField]
    private GameObject crosshair;

    [SerializeField]
    private InventoryUI inventoryUI;

    [SerializeField]
    private CharacterUI characterUI;

    [SerializeField]
    private Inventory inventory;
    private IInteractable interactable;

    [SerializeField]
    private HealthBar healthbar;
    
    [SerializeField]
    private EssenceBar activeEssence;
    
    [SerializeField]
    private EssenceBar inactiveEssence;
    private int gravityEssence;
    private int poisonEssence;
    public int spellDamage;
    private Soul activeSoul;
    private Soul inactiveSoul;
    [SerializeField]
    private Spellbook spellbook;
    private int maxEssence;
    [SerializeField]
    private Combat combat;

    private void Start()
    {
        Cursor.visible = false;
        activeSoul = Soul.gravity;
        inactiveSoul = Soul.poison;
        CalculateStats();
        activeEssence.SetMaxEssence(this.maxEssence);
        inactiveEssence.SetMaxEssence(this.maxEssence);
        this.gravityEssence = this.maxEssence;
        this.poisonEssence = this.maxEssence;
    }
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Magnitude", movement.magnitude);

        Move(movement);
        Aim();

        if (Input.GetKeyDown("i"))
        {
            inventoryUI.ToggleInventory();
        }
        if (Input.GetKeyDown("c"))
        {
            characterUI.ToggleCharacter();
        }
        if (Input.GetKeyDown("e"))
        {
            SwapActiveSoul();
        }
        if (Input.GetKeyDown("q"))
        {
            int activeEssenceAmount = GetActiveEssenceAmount();
            if(activeEssenceAmount > 3){
                StartCoroutine(combat.CastSoulAbility(activeSoul));
            }
        }

    }
    void Move(Vector3 movement)
    {
        rb.velocity = new Vector2(movement.x * speed, movement.y * speed);
    }
    private void TakeDamage(int damage)
    {
        this.currentHealth -= damage;
        healthbar.SetHealth(this.currentHealth);
    }
    public void UseEssence(int essence){
        if(activeSoul == Soul.gravity){
            this.gravityEssence -= essence;
            this.activeEssence.SetEssence(this.gravityEssence);
        }
        else if (activeSoul == Soul.poison){
            this.poisonEssence -= essence;
            this.activeEssence.SetEssence(this.poisonEssence);
        }
    }
    public void SwapActiveSoul(){
        Soul tempSoul = activeSoul;
        activeSoul = inactiveSoul;
        inactiveSoul = tempSoul;
        EssenceBar temp = activeEssence;
        activeEssence = inactiveEssence;
        inactiveEssence = temp;
    }
    void Aim()
    {
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        crosshair.transform.localPosition = worldPosition;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Loot")
        {
            Loot loot = collision.gameObject.GetComponent<LootInfo>().loot;
            GetComponent<Inventory>().GiveItem(loot.id);
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "NPC"){
            interactable = collision.GetComponent<IInteractable>();
            interactable.Interact();
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.tag == "NPC"){
            interactable.StopInteract();
            interactable = null;
        }
    }
    private void CalculateStats(){
        int strength = 0;
        int dexterity = 0;
        int intellect = 0;
        int vitality = 0;

        CharacterEquipment equipment = inventory.equipment;
        List<LootEquipment> equipped = equipment.GetEquipment();

        foreach (LootEquipment l in equipped){
            Dictionary<string, int> stats = l.stats;
            if(l.equipmentType == EquipmentType.mainhand){
                mainHandMaxDamage = stats["mainHandMaxDamage"];
                mainHandMinDamage = stats["mainhandMinDamage"];
            }
            if(stats.ContainsKey("strength")){
                strength += stats["strength"];
            }
            if(stats.ContainsKey("dexterity")){
                dexterity += stats["dexterity"];
            }
            if(stats.ContainsKey("intellect")){
                intellect += stats["intellect"];
            }
            if(stats.ContainsKey("vitality")){
                vitality += stats["vitality"];
            }
        }

        this.strength = strength;
        this.dexterity = dexterity;
        this.intellect = intellect;
        this.vitality = vitality;
        UpdateModifiers();
    }
    private void CalculateEssence(){
        this.maxEssence = 5 + this.intellect;
    }
    private void CalculateSpellDamage(){
        this.spellDamage = 1 + this.intellect;
    }
    private void UpdateModifiers(){
        base.CalculateBaseHealth();
        base.CalculateInteralAttackCD();
        CalculateEssence();
        CalculateSpellDamage();
    }
    public Soul GetActiveSoul(){
        return this.activeSoul;
    }
    public int GetActiveEssenceAmount(){
        if(activeSoul == Soul.gravity){
            return this.gravityEssence;
        }
        else if (activeSoul == Soul.poison){
            return this.poisonEssence;
        }
        else {
            return 0;
        }
    }
}
