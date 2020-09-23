using UnityEngine;
using System.Collections;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
using Cinemachine;

public enum MoveDirection { Up, Down, Left, Right }

public class Player : Character
{
    [Header("Components")]
    public Transform castPos;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public PlayerCombat combat;
    [SerializeField] protected PlayerResources resources;
    [SerializeField] public Spellbook spellbook;
    [SerializeField] public PlayerRelic relics;
    [SerializeField] public CinemachineVirtualCamera cam;
    
    [Header("Currencies")]
    protected int gold;
    public int Gold { get { return gold;} set { gold += value; }}
    protected int souls;
    public int Souls { get { return souls;} set { souls += value; }}
    
    [Header("UI Panels")]
    [SerializeField] private UISingleton uISingleton;
    [SerializeField] public TextPanelUI soulPanel;
    [SerializeField] private RecapUI recapUI;
    [SerializeField] private RelicUI relicUI;
    [SerializeField] private ItemTooltip itemTooltip;
    [SerializeField] private ItemSaveManager itemSaveManager;
    
    [Header("Demons")]
    public Imp Imp;
    public VoidGuardian VoidGuardian;
    public Infernal Infernal;

    [Header("Etc")]
    public string scene;
    public bool backToDungeon;
    public Direction lastDirection;
    public Room map;
    private bool isMoveDisabled = false;
    public MoveDirection lastMoveDirection = MoveDirection.Up;
    public Vector3 movement;
    public bool canInteract;
    private float disableTime = 0.25f;

    private void OnValidate(){
        if(itemTooltip == null){
            itemTooltip = FindObjectOfType<ItemTooltip>();
        }
    }
    protected override void Awake(){
        base.Awake();
    }

    protected override void Start()
    {
        // Find All UI Objects
        uISingleton = UISingleton.Instance;
        soulPanel = uISingleton.GetComponentInChildren<SoulPanel>();
        recapUI = uISingleton.GetComponentInChildren<RecapUI>();
        relicUI = uISingleton.GetComponentInChildren<RelicUI>();
        itemTooltip = uISingleton.GetComponentInChildren<ItemTooltip>();
        // itemSaveManager = FindObjectOfType<ItemSaveManager>(); TODO: Save System

        soulPanel.SetTexts(this.souls);
        soulPanel.UpdateTextsValues();
        backToDungeon = false;
        canInteract = true;
        lastDirection = Direction.North;
        map = new Room(new Vector2(0,0), true, true, true, true); // default path
    }
    protected override void Update()
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

    public void SetPlayerCurrency(){
        soulPanel.SetTexts(this.souls);
        soulPanel.UpdateTextsValues();
    }
    private bool CanAfford(BaseItemSlot itemSlot){
        return itemSlot.Item.soulValue <= Souls;
    }
    private void AddCurrency(Item item){
        Souls = Souls + item.soulValue;
        SetPlayerCurrency();
    }
    private void RemoveCurrency(Item item){
        Souls = Souls - item.soulValue;
        SetPlayerCurrency();
    }

    private void Move()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Magnitude", movement.magnitude);

        if (movement.x != 0.0f || movement.y != 0.0f){
            anim.SetFloat("LastHorizonal", movement.x);
            anim.SetFloat("LastVertical", movement.y);
            SetLastMoveDirection(movement);
        }
        rb.velocity = new Vector2(movement.x * speed, movement.y * speed);
    }
    public MoveDirection GetMoveDirection(){
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        if(movement.x == 0 && movement.y == 0) return lastMoveDirection;
        if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y)){
            if(movement.x >= 0){
                return MoveDirection.Right;
            } else {
                return MoveDirection.Left;
            }
        }
        else {
            if(movement.y >= 0){
                return MoveDirection.Up;
            } else {
                return MoveDirection.Down;
            }
        }
    }
    private void SetLastMoveDirection(Vector3 movement){
        if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y)){
            if(movement.x >= 0){
                lastMoveDirection = MoveDirection.Right;
            } else {
                lastMoveDirection = MoveDirection.Left;
            }
        }
        else {
            if(movement.y >= 0){
                lastMoveDirection = MoveDirection.Up;
            } else {
                lastMoveDirection = MoveDirection.Down;
            }
        }
    }
    public IEnumerator DisableMovement(float time){
        isMoveDisabled = true;
        yield return new WaitForSeconds(time);
        isMoveDisabled = false;
    }
    public IEnumerator DisableInteract(float time)
    {
        if(canInteract){
            canInteract = false;
            yield return new WaitForSeconds(time);
            anim.SetTrigger("CanBeDamaged");
            canInteract = true;
        }
    }
    public override void Hit(int damage){
        StartCoroutine(DisableInteract(disableTime));
        anim.SetTrigger("Blink");
        base.Hit(damage);
        this.TakeDamage(damage);
    }
    public override void TakeDamage(int damage){
        base.TakeDamage(damage);
        resources.SetSanity();
    }
    public override void Dead(){
        if(isDead){
            recapUI.ShowMenu();
        }
    }
    public void Respawn() {
        currentHealth = health;
        resources.SetSanity();
        isDead = false;
    }
    public void KnockPlayer(Transform objectApplyingForce,
                            float magnitude,
                            float disableTime)
    {
        var dir = objectApplyingForce.position - transform.position;
        rb.AddForce(-dir.normalized * magnitude);
        StartCoroutine(DisableMovement(disableTime));
    }
    public Vector3 GetShotDirection(){
        return combat.shotDirection;
    }

    public void SetDemonLocations(){
        if (Imp != null) Imp.gameObject.transform.position = this.gameObject.transform.position;
        if (VoidGuardian != null) Imp.gameObject.transform.position = this.gameObject.transform.position;
        if (Infernal != null) Imp.gameObject.transform.position = this.gameObject.transform.position;
    }
}
