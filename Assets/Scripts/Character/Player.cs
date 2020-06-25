using UnityEngine;
using System.Collections.Generic;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
using UnityEngine.UI;

public enum Soul {
    gravity,
    poison
}
public class Player : Character
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Animator anim;
    
    [SerializeField] private GameObject crosshair;

    private IInteractable interactable;

    [SerializeField] private HealthBar healthbar;
    
    [SerializeField] private EssenceBar activeEssence;
    
    [SerializeField] private EssenceBar inactiveEssence;
    private int gravityEssence;
    private int poisonEssence;
    public int spellDamage;
    private Soul activeSoul;
    private Soul inactiveSoul;
    private Spellbook spellbook;
    private int maxEssence;
    [SerializeField] private Combat combat;
    private int gold;
    private int souls;
    private int weight;
    [Space]
    public Inventory Inventory;
    public EquipmentPanel EquipmentPanel;
    [SerializeField] StatPanel statPanel;
    [SerializeField] ItemTooltip itemTooltip;
    [SerializeField] Image draggableItem;
    private BaseItemSlot draggedSlot;
    [SerializeField] ItemSaveManager itemSaveManager;


    private void OnValidate(){
        if(itemTooltip == null){
            itemTooltip = FindObjectOfType<ItemTooltip>();
        }
    }
    protected override void Awake(){
        base.Awake();
        strength = new CharacterStat(1);
        dexterity = new CharacterStat(1);
        intellect = new CharacterStat(1);
        vitality = new CharacterStat(1);

        // Setup Events
        Inventory.OnRightClickEvent += InventoryRightClick;
        EquipmentPanel.OnRightClickEvent += EquipmentPanelRightClick;

        Inventory.OnPointerEnterEvent += ShowTooltip;
        EquipmentPanel.OnPointerEnterEvent += ShowTooltip;

        Inventory.OnPointerExitEvent += HideTooltip;
        EquipmentPanel.OnPointerExitEvent += HideTooltip;

        Inventory.OnBeginDragEvent += BeginDrag;
        EquipmentPanel.OnBeginDragEvent += BeginDrag;

        Inventory.OnEndDragEvent += EndDrag;
        EquipmentPanel.OnEndDragEvent += EndDrag;

        Inventory.OnDragEvent += Drag;
        EquipmentPanel.OnDragEvent += Drag;

        Inventory.OnDropEvent += Drop;
        EquipmentPanel.OnDropEvent += Drop;

    }
	private void ShowTooltip(BaseItemSlot itemSlot)
	{
		if (itemSlot.Item != null)
		{
			itemTooltip.ShowTooltip(itemSlot.Item);
		}
	}
	private void HideTooltip(BaseItemSlot itemSlot)
	{
		if (itemTooltip.gameObject.activeSelf)
		{
			itemTooltip.HideTooltip();
		}
	}
	private void BeginDrag(BaseItemSlot itemSlot)
	{
		if (itemSlot.Item != null)
		{
			draggedSlot = itemSlot;
			draggableItem.sprite = itemSlot.Item.Icon;
			draggableItem.transform.position = Input.mousePosition;
			draggableItem.gameObject.SetActive(true);
		}
	}
	private void Drag(BaseItemSlot itemSlot)
	{
		draggableItem.transform.position = Input.mousePosition;
	}
	private void EndDrag(BaseItemSlot itemSlot)
	{
		draggedSlot = null;
		draggableItem.gameObject.SetActive(false);
	}
	private void Drop(BaseItemSlot dropItemSlot)
	{
		if (draggedSlot == null) return;

		// if (dropItemSlot.CanAddStack(dragItemSlot.Item))
		// {
		// 	AddStacks(dropItemSlot);
		// }
		if (dropItemSlot.CanReceiveItem(draggedSlot.Item) && draggedSlot.CanReceiveItem(dropItemSlot.Item))
		{
			SwapItems(dropItemSlot);
		}
	}
    private void SwapItems(BaseItemSlot dropItemSlot)
	{
		EquippableItem dragEquipItem = draggedSlot.Item as EquippableItem;
		EquippableItem dropEquipItem = dropItemSlot.Item as EquippableItem;

		if (dropItemSlot is EquipmentSlot)
		{
			if (dragEquipItem != null) dragEquipItem.Equip(this);
			if (dropEquipItem != null) dropEquipItem.Unequip(this);
		}
		if (draggedSlot is EquipmentSlot)
		{
			if (dragEquipItem != null) dragEquipItem.Unequip(this);
			if (dropEquipItem != null) dropEquipItem.Equip(this);
		}
		statPanel.UpdateStatValues();

		Item draggedItem = draggedSlot.Item;
		//int draggedItemAmount = draggedSlot.Amount;

		draggedSlot.Item = dropItemSlot.Item;
		//draggedSlot.Amount = dropItemSlot.Amount;

		dropItemSlot.Item = draggedItem;
		//dropItemSlot.Amount = draggedItemAmount;
	}
    private void Start()
    {
        statPanel.SetStats(strength, dexterity, intellect, vitality);
        statPanel.UpdateStatValues(); 

        itemSaveManager.LoadEquipment(this);
        itemSaveManager.LoadInventory(this);

        // Old
        spellbook = GetComponent<Spellbook>();
        //Cursor.visible = false;
        activeSoul = Soul.gravity;
        inactiveSoul = Soul.poison;
        //activeEssence.SetMaxEssence(this.maxEssence);
        //inactiveEssence.SetMaxEssence(this.maxEssence);
        this.gravityEssence = this.maxEssence;
        this.poisonEssence = this.maxEssence;
        this.gold = 1;
        this.souls = 1;
        this.weight = 1;
    }
    private void OnDestroy()
	{
        itemSaveManager.SaveEquipment(this);
        itemSaveManager.SaveInventory(this);
	}
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Magnitude", movement.magnitude);

        Move(movement);
        Aim();

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
    private void InventoryRightClick(BaseItemSlot itemSlot){
        EquippableItem equippableItem = itemSlot.Item as EquippableItem;
        if(equippableItem != null){
            Equip(equippableItem);
        }
        else if (itemSlot.Item is UsableItem){
            UsableItem useableItem = (UsableItem) itemSlot.Item;
            useableItem.Use(this);

            if(useableItem.isConsumable){
                Inventory.RemoveItem(useableItem);
                //useableItem.Destroy();
            }
        }
    }

    private void EquipmentPanelRightClick(BaseItemSlot itemSlot){
        EquippableItem equippableItem = itemSlot.Item as EquippableItem;
        if(equippableItem != null){
            Unequip(equippableItem);
        }
    }

    public void Equip(EquippableItem item){
        if(Inventory.RemoveItem(item)){
            EquippableItem previousItem;
            if(EquipmentPanel.AddItem(item, out previousItem)){
                if(previousItem != null){
                    Inventory.AddItem(previousItem);
                    previousItem.Unequip(this);
                    statPanel.UpdateStatValues();
                }
                item.Equip(this);
                statPanel.UpdateStatValues();
            }
            else {
                Inventory.RemoveItem(item);
            }
        }
    }

    public void Unequip(EquippableItem item){
        if(!Inventory.CanAddItem(item) && EquipmentPanel.RemoveItem(item)){
            item.Unequip(this);
            statPanel.UpdateStatValues();
            Inventory.AddItem(item);
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
            //GetComponent<Inventory>().GiveItem(loot.id);
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
    private void CalculateEssence(){
        this.maxEssence = 5 + (int)this.intellect.Value;
    }
    private void CalculateSpellDamage(){
        this.spellDamage = 1 + (int)this.intellect.Value;
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
    public int GetGold(){
        return this.gold;
    }

    public int GetSoul(){
        return this.souls;
    }

    public int GetWeight(){
        return this.weight;
    }

    public void UpdateGold(int gold){
        this.gold += gold;
    }
    public void UpdateSouls(int souls){
        this.souls += souls;
    }
    public void UpdateWeight(int weight){
        this.weight += weight;
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

    public void UpdateStatValues(){
        statPanel.UpdateStatValues();
    }
}
