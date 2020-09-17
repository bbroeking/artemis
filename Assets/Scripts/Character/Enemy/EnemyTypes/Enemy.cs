using UnityEngine;
using Pathfinding;
using System.Collections;

public class Enemy : Character, IInteractable
{
    [Header("Enemy")]
    [SerializeField] protected AIDestinationSetter aIDestination;
    [SerializeField] protected LootTable lootTable;
    [SerializeField] public Transform spawnLocation;
    private Player player;
    private bool isInAggroRange;
    public bool IsInAggroRange { get { return isInAggroRange; } set { isInAggroRange = value; }}
    private float aggroCooldown = 5f;
    private float internalAggroCooldown;
    private float distanceFromSpawn = 100f;
    private float disableTime = 0.25f;
    private float magnitude = 200.0f;
    public bool canBeDamaged = true;
    private float hitCooldown = 0.5f;
    protected bool isActivateDelay = true;
    protected float activateDelay = 1.15f;
    private bool spawnBonusLoot = false;
    public bool SpawnBonusLoot { get { return spawnBonusLoot; } set { spawnBonusLoot = value; }}

    protected override void Awake(){
        base.Awake();
        lootTable = gameObject.GetComponentInParent<LootTable>();
        player = PlayerSingleton.Instance.player;
    }

    protected override void Start(){
        if (spawnLocation == null) spawnLocation = this.transform; // current location is spawn location if not spawned with spawner
        isInAggroRange = false;
        internalAggroCooldown = 0f;
        aIPath = GetComponent<AIPath>();
        aIPath.maxSpeed = this.speed;
        StartCoroutine(ActivateEnemyDelay());
    }

    protected override void Update(){
        UpdateAnimationValues();
        if (!isActivateDelay){
            SetTarget();
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
        if (isDead) return;
        StartCoroutine(HitCooldown());
        base.TakeDamage(damage);
        if (this.isDead){
            aIDestination.target = null;
            anim.SetTrigger("Dead");
        }
    }

    public virtual void SpawnLoot()
    {
        lootTable.SpawnLoot();
    }

    public void Interact(Player player)
    {
        if (player.canInteract && !isDead){
            player.Hit(this.baseDamage);
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

    public void SlowUnit(float percentSlow){
        aIPath.maxSpeed = this.speed * percentSlow;
    }

    /*
    Sets the unit's health to 1, used for the curse of weakness
    */
    public void MakeBrittle(){
        this.health = 1;
        this.currentHealth = 1;
    }
}
