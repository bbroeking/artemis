using UnityEngine;
using Pathfinding;
using System.Collections;

public class Enemy : Character, IInteractable
{
    [Header("Enemy")]
    [SerializeField] protected AIDestinationSetter aIDestination;
    [SerializeField] LootTable lootTable;
    [SerializeField] Sprite sprite;
    [SerializeField] public Transform spawnLocation;
    private Player player;
    private bool isInAggroRange;
    public bool IsInAggroRange { get { return isInAggroRange; } set { isInAggroRange = value; }}
    private float aggroCooldown = 5f;
    private float internalAggroCooldown;
    private float distanceFromSpawn = 3f;
    private float disableTime = 0.25f;
    private float magnitude = 200.0f;
    private bool isInteractable = true;
    private float interactCooldown = 0.35f;

    private void OnValidate(){
        lootTable = gameObject.GetComponentInParent<LootTable>();
    }

    protected override void Awake(){
        base.Awake();
        lootTable = gameObject.GetComponentInParent<LootTable>();
        player = SingletonPlayer.Instance.player;
    }

    void Start(){
        isInAggroRange = false;
        internalAggroCooldown = 0f;
    }

    void Update(){
        SetTarget();
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
        base.TakeDamage(damage);
        if (this.isDead){
            SpawnLootAndDestroy();
        }
    }

    private void SpawnLootAndDestroy()
    {
        lootTable.SpawnLoot();
        Destroy(this.gameObject);
    }

    public void Interact(Player player)
    {
        if (isInteractable){
            StartCoroutine(Cooldown());
            player.TakeDamage(this.baseDamage);
            player.KnockPlayer(this.transform, magnitude);
            StartCoroutine(player.DisableMovement(this.disableTime));
        }
    }

    public void StopInteract(){}

    public IEnumerator Cooldown()
    {
        if(isInteractable){
            isInteractable = false;
            yield return new WaitForSeconds(interactCooldown);
            isInteractable = true;
        }
    }
}
