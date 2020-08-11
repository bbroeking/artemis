using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
using UnityEngine.UI;

public class Player : Character
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] protected Combat combat;
    [SerializeField] protected PlayerResources resources;
    [SerializeField] protected Spellbook spellbook;
    
    [Header("Currencies")]
    protected int gold;
    public int Gold { get { return gold;} set { gold = value; }}
    protected int souls;
    public int Souls { get { return souls;} set { souls = value; }}
    protected int weight;
    public int Weight { get { return weight;} set { weight = value; }}
    
    [Header("UI Panels")]
    [SerializeField] public Inventory Inventory;
    [SerializeField] public EquipmentPanel EquipmentPanel;
    [SerializeField] private StatPanel statPanel;
    [SerializeField] public CurrencyPanel currencyPanel;
    [SerializeField] private ShopPanel ShopPanel;
    [SerializeField] private DeathMenu deathMenu;
    [SerializeField] private ItemTooltip itemTooltip;
    [SerializeField] private Image draggableItem;
    [SerializeField] private ItemSaveManager itemSaveManager;
    [SerializeField] protected BaseItemSlot draggedSlot;
    
    [Header("Etc")]
    public Vector3 lastDungeonLocation;
    public Vector3 LastDungeonLocation { get { return lastDungeonLocation; } set { lastDungeonLocation = value; } }
    public string scene;
    public bool backToDungeon;
    public Direction lastDirection;
    public string map;
    private bool isMoveDisabled = false;

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
        ShopPanel.OnRightClickEvent += InventoryRightClick; // this needs to have a purchase method

        Inventory.OnPointerEnterEvent += ShowTooltip;
        EquipmentPanel.OnPointerEnterEvent += ShowTooltip;
        ShopPanel.OnPointerEnterEvent += ShowTooltip;

        Inventory.OnPointerExitEvent += HideTooltip;
        EquipmentPanel.OnPointerExitEvent += HideTooltip;
        ShopPanel.OnPointerExitEvent += HideTooltip;

        Inventory.OnBeginDragEvent += BeginDrag;
        EquipmentPanel.OnBeginDragEvent += BeginDrag;
        ShopPanel.OnBeginDragEvent += BeginDrag;

        Inventory.OnEndDragEvent += EndDrag;
        EquipmentPanel.OnEndDragEvent += EndDrag;
        ShopPanel.OnEndDragEvent += EndDrag;

        Inventory.OnDragEvent += BeginDragInventory;
        EquipmentPanel.OnDragEvent += BeginDragEquipment;
        ShopPanel.OnDragEvent += BeginDragShop;

        Inventory.OnDropEvent += Drop;
        EquipmentPanel.OnDropEvent += Drop;
        ShopPanel.OnDropEvent += DropShop;

    }

    private void Start()
    {
        statPanel.SetStats(strength, dexterity, intellect, vitality);
        statPanel.UpdateStatValues(); 

        itemSaveManager.LoadEquipment(this);
        itemSaveManager.LoadInventory(this);
        itemSaveManager.LoadCurrency(this);

        this.weight = Inventory.GetWeight(); // Need to calcuate the items weight
        currencyPanel.SetCurrency(this.gold, this.souls, this.weight);
        currencyPanel.UpdateCurrencyValues();
        backToDungeon = false;
        lastDirection = Direction.North;
        map = "Map/TBLR/TBLR Base"; // default path
    }
    private void OnDestroy()
	{
        itemSaveManager.SaveEquipment(this);
        itemSaveManager.SaveInventory(this);
        itemSaveManager.SaveCurrency(this);
	}
    void Update()
    {
        Dead();
        if (!isMoveDisabled && !isDead){
            Move();
        }
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

    private void BeginDragEquipment(BaseItemSlot itemSlot)
    {
        if (itemSlot.Item != null)
		{
            draggedSlot.dragType = SlotType.Equipment;
            BeginDrag(itemSlot);
        }
    }
    private void BeginDragInventory(BaseItemSlot itemSlot)
    {
        if (itemSlot.Item != null)
		{
            draggedSlot.dragType = SlotType.Inventory;
            BeginDrag(itemSlot);
        }
    }
    private void BeginDragShop(BaseItemSlot itemSlot)
    {
        if (itemSlot.Item != null)
		{
            draggedSlot.dragType = SlotType.Shop;
            BeginDrag(itemSlot);
        }
    }
    
	private void Drag(BaseItemSlot itemSlot)
	{
		draggableItem.transform.position = Input.mousePosition;
	}
	private void EndDrag(BaseItemSlot itemSlot)
	{
        if (draggedSlot != null){
            draggedSlot.dragType = SlotType.None;
		    draggedSlot = null;
		    draggableItem.gameObject.SetActive(false);
        }
	}

    private void DropShop(BaseItemSlot dropItemSlot){
        if (draggedSlot == null) return;
        if (dropItemSlot.dragType == SlotType.Equipment) return;
        if (dropItemSlot.dragType == SlotType.Shop) return;
        if (dropItemSlot.CanReceiveItem(dropItemSlot.Item)) {
            AddCurrency(draggedSlot.Item);
            SwapItems(dropItemSlot);
        }
    }

	private void Drop(BaseItemSlot dropItemSlot)
	{
		if (draggedSlot == null) return;

        if (draggedSlot.dragType == SlotType.Shop && dropItemSlot.Item == null && CanAfford(draggedSlot)){
            RemoveCurrency(draggedSlot.Item);
            SwapItems(dropItemSlot);
        }

		else if (dropItemSlot.CanReceiveItem(draggedSlot.Item) && draggedSlot.CanReceiveItem(dropItemSlot.Item))
		{
			SwapItems(dropItemSlot);
		}
	}
    public void SetPlayerCurrency(){
        currencyPanel.SetCurrency(this.gold, this.souls, this.weight);
        currencyPanel.UpdateCurrencyValues();
    }
    private bool CanAfford(BaseItemSlot itemSlot){
        return itemSlot.Item.goldValue <= Gold;
    }
    private void AddCurrency(Item item){
        Gold = Gold + item.goldValue;
        Souls = Souls + item.soulValue;
        SetPlayerCurrency();
    }
    private void RemoveCurrency(Item item){
        Gold = Gold - item.goldValue;
        Souls = Souls - item.soulValue;
        SetPlayerCurrency();
    }
    private void BasicSwap(BaseItemSlot dropItemSlot){
        Item draggedItem = draggedSlot.Item;
		draggedSlot.Item = null;
		dropItemSlot.Item = draggedItem;
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
		draggedSlot.Item = dropItemSlot.Item;
		dropItemSlot.Item = draggedItem;
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
                useableItem.Destroy();
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
    private void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Magnitude", movement.magnitude);

        if (movement.x != 0.0f || movement.y != 0.0f){
            anim.SetFloat("LastHorizonal", movement.x);
            anim.SetFloat("LastVertical", movement.y);
        }
        rb.velocity = new Vector2(movement.x * speed, movement.y * speed);
    }
    public IEnumerator DisableMovement(float time){
        isMoveDisabled = true;
        yield return new WaitForSeconds(time);
        isMoveDisabled = false;
    }
    public void UpdateStatValues(){
        statPanel.UpdateStatValues();
    }
    public override void TakeDamage(int damage){
        base.TakeDamage(damage);
        resources.SetHealthbar();
    }
    public override void Dead(){
        if(isDead){
            deathMenu.ShowMenu();
        }
    }
    public void Respawn() {
        currentHealth = health;
        resources.SetHealthbar();
        isDead = false;
    }
    public void KnockPlayer(Transform objectApplyingForce, float magnitude){
        var dir = objectApplyingForce.position - transform.position;
        dir.Normalize();
        rb.AddForce(-dir * magnitude);
    }
}
