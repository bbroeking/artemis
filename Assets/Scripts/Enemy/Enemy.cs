using UnityEngine;
using Pathfinding;

public class Enemy : Character
{
    [SerializeField] AIDestinationSetter aIDestination;
    [SerializeField] LootTable lootTable;
    [SerializeField] Sprite sprite;
    [SerializeField] public Transform spawnLocation;
    private Player player;
    private bool isInAggroRange;
    public bool IsInAggroRange { get { return isInAggroRange; } set { isInAggroRange = value; }}
    private float aggroCooldown = 5f;
    private float internalAggroCooldown;
    public float distanceFromSpawn;


    private void OnValidate(){
        lootTable = gameObject.GetComponentInParent<LootTable>();
    }

    protected override void Awake(){
        base.Awake();
        lootTable = gameObject.GetComponentInParent<LootTable>();
        player = GameObject.FindGameObjectWithTag("player").GetComponent<Player>(); // TODO find a better way to store player object for other object to use
    }
    void Start(){
        isInAggroRange = false;
        internalAggroCooldown = 0f;
        distanceFromSpawn = 3f;
    }

    void Update(){
        SetTarget();
    }

    void SetTarget(){
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
        base.TakeDamage(damage);
        if (this.dead){
            SpawnLootAndDestroy();
        }
    }

    private void SpawnLootAndDestroy()
    {
        lootTable.SpawnLoot();
        Destroy(this.gameObject);
    }
}
