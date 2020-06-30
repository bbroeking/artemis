using UnityEngine;
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
    public int Gold { get { return gold;} set { gold += value; }}
    protected int souls;
    public int Souls { get { return souls;} set { souls += value; }}
    protected int weight;
    public int Weight { get { return weight;} set { weight += value; }}
    
    [Header("UI Panels")]
    [SerializeField] public Inventory Inventory;
    [SerializeField] public EquipmentPanel EquipmentPanel;
    [SerializeField] StatPanel statPanel;
    [SerializeField] public CurrencyPanel currencyPanel;
    [SerializeField] ShopPanel ShopPanel;
    [SerializeField] DeathMenu deathMenu;
    [SerializeField] ItemTooltip itemTooltip;
    [SerializeField] Image draggableItem;
    protected BaseItemSlot draggedSlot;
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

        Inventory.OnDragEvent += Drag;
        EquipmentPanel.OnDragEvent += Drag;
        ShopPanel.OnDragEvent += Drag;

        Inventory.OnDropEvent += Drop;
        EquipmentPanel.OnDropEvent += Drop;
        ShopPanel.OnDropEvent += Drop;

    }
    private void Start()
    {
        statPanel.SetStats(strength, dexterity, intellect, vitality);
        statPanel.UpdateStatValues(); 

        itemSaveManager.LoadEquipment(this);
        itemSaveManager.LoadInventory(this);

        // Currency
        this.gold = 1;
        this.souls = 1;
        this.weight = 1;
        currencyPanel.SetCurrency(this.gold, this.souls, this.weight);
        currencyPanel.UpdateCurrencyValues();
    }
    private void OnDestroy()
	{
        itemSaveManager.SaveEquipment(this);
        itemSaveManager.SaveInventory(this);
	}
    void Update()
    {
        Dead();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Magnitude", movement.magnitude);

        Move(movement);
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

		if (dropItemSlot.CanReceiveItem(draggedSlot.Item) && draggedSlot.CanReceiveItem(dropItemSlot.Item))
		{
			SwapItems(dropItemSlot);
		}
	}
    public void SetPlayerCurrency(){
        currencyPanel.SetCurrency(this.gold, this.souls, this.weight);
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
    void Move(Vector3 movement)
    {
        rb.velocity = new Vector2(movement.x * speed, movement.y * speed);
    }
    public void UpdateStatValues(){
        statPanel.UpdateStatValues();
    }

    public override void Hit(int damage){
        base.TakeDamage(damage);
        resources.SetHealthbar();
    }

    public override void Dead(){
        if(dead){
            deathMenu.ShowMenu();
        }
    }
}
