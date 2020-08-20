using UnityEngine;
using Pathfinding;
using System.Collections;

public class Enemy : Character, IInteractable
{
    [Header("Enemy")]
    [SerializeField] protected AIDestinationSetter aIDestination;
    [SerializeField] protected AIPath aIPath;
    [SerializeField] private Animator anim;
    [SerializeField] LootTable lootTable;
    [SerializeField] public Transform spawnLocation;
    private Player player;
    private bool isInAggroRange;
    public bool IsInAggroRange { get { return isInAggroRange; } set { isInAggroRange = value; }}
    private float aggroCooldown = 5f;
    private float internalAggroCooldown;
    private float distanceFromSpawn = 100f;
    private float disableTime = 0.25f;
    private float magnitude = 200.0f;
    private float interactCooldown = 0.35f;
    private bool canBeDamaged = true;
    private float hitCooldown = 0.25f;
    protected bool isActivateDelay = true;
    protected float activateDelay = 1.15f;

    private void OnValidate(){
        lootTable = gameObject.GetComponentInParent<LootTable>();
    }

    protected override void Awake(){
        base.Awake();
        lootTable = gameObject.GetComponentInParent<LootTable>();
        player = PlayerSingleton.Instance.player;
    }

    void Start(){
        isInAggroRange = false;
        internalAggroCooldown = 0f;
        StartCoroutine(ActivateEnemyDelay());
    }

    void Update(){
        UpdateAnimationValues();
        if (!isActivateDelay){
            SetTarget();
        }
    }

    protected virtual void UpdateAnimationValues(){
        Vector3 velo = aIPath.velocity;
        anim.SetFloat("Horizontal", velo.x);
        anim.SetFloat("Vertical", velo.y);
        anim.SetFloat("Magnitude", velo.magnitude);

        if (velo.x != 0.0f || velo.y != 0.0f){
            anim.SetFloat("LastHorizontal", velo.x);
            anim.SetFloat("LastVertical", velo.y);
        }
    }

    protected virtual void SetTarget(){
        float distanceTravelled = Vector2.Distance(spawnLocation.transform.position, this.transform.position);
        if(distanceTravelled > distanceFromSpawn){
            aIDestination.target = spawnLocation;
        } else if(internalAggroCooldown <= 0 && isInAggroRange){
            aIDestination.target = player.transform;
            internalAggroCooldown = aggroCooldown;
        } else {
            internalAggroCooldown -= Time.deltaTime;
        }
    }

    public override void Hit(int damage)
    {
        if (!canBeDamaged) return;
        StartCoroutine(HitCooldown());
        base.TakeDamage(damage);
        if (this.isDead){
            aIDestination.target = null;
            anim.SetTrigger("Dead");
            Invoke("SpawnLootAndDestroy", 2f);
        }
    }

    private void SpawnLootAndDestroy()
    {
        lootTable.SpawnLoot();
        Destroy(this.gameObject);
    }

    public void Interact(Player player)
    {
        if (player.canInteract && !isDead){
            player.TakeDamage(this.baseDamage);
            player.KnockPlayer(this.transform, magnitude, disableTime);
        }
    }

    public void StopInteract(){}
    public IEnumerator HitCooldown(){
        if(canBeDamaged){
            canBeDamaged = false;
            yield return new WaitForSeconds(hitCooldown);
            canBeDamaged = true;
        }
    }
    protected IEnumerator ActivateEnemyDelay()
    {
        yield return new WaitForSeconds (activateDelay);
        isActivateDelay = false;
    }
}
