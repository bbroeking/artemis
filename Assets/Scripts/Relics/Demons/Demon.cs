using UnityEngine;
using Pathfinding;

public class Demon : Character
{
    [Header("Demon")]
    [SerializeField] protected AIDestinationSetter aIDestination;
    [SerializeField] protected AIPath aIPath;
    protected Player player;
    protected override void Start()
    {
        player = PlayerSingleton.Instance.player;
        aIDestination = GetComponent<AIDestinationSetter>();
        aIPath = GetComponent<AIPath>();

        aIPath.maxSpeed = this.speed;
        aIDestination.target = player.transform;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if(this.isDead) Dead();
    }

    public override void Hit(int damage){
        base.Hit(damage);
        this.TakeDamage(damage);
    }

    public override void Dead(){
        // TODO create death animation
        Destroy(this.gameObject);
    }
}
