using UnityEngine;
using System.Collections.Generic;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Player : Character
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private HealthBar healthbar;
    [SerializeField]
    private GameObject crosshair;
    [SerializeField]
    private InventoryUI inventoryUI;
    [SerializeField]
    private CharacterUI characterUI;
    [SerializeField]
    private Inventory inventory;
    private IInteractable interactable;

    private void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Magnitude", movement.magnitude);

        Move(movement);
        Aim();

        if (Input.GetKeyDown("i") == true)
        {
            inventoryUI.ToggleInventory();
        }
        if (Input.GetKeyDown("c") == true)
        {
            characterUI.ToggleCharacter();
        }

    }
    void Move(Vector3 movement)
    {
        rb.velocity = new Vector2(movement.x * speed, movement.y * speed);
        // if(movement.x > 0){
        //     Dictionary<string, dynamic> characterStats = base.GetCharacterStats();
        //     foreach(KeyValuePair<string, dynamic> stat in characterStats){
        //         Debug.Log(stat.Key + ": " + stat.Value);
        //     }
        // }
    }
    private void HandleHealth()
    {
        PermanentUI.perm.health -= 1;
        healthbar.SetHealth(PermanentUI.perm.health);
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

    private void UpdateModifiers(){
        base.CalculateBaseHealth();
        base.CalculateInteralAttackCD();
    }
}
