using UnityEngine;
using Pathfinding;

public class Demon : Character
{
    [Header("Demon")]
    [SerializeField] protected AIDestinationSetter aIDestination;
    protected DemonType demonType;
    protected Player player;
    protected RelicItemSlot associatedRelicSlot;
    protected override void Start()
    {
        player = PlayerSingleton.Instance.player;
        aIDestination = GetComponent<AIDestinationSetter>();
        aIPath = GetComponent<AIPath>();
        anim = GetComponent<Animator>();
        
        // Link UI Component
        RelicItemSlot[] relicSlots = UISingleton.Instance.GetComponentsInChildren<RelicItemSlot>();
        foreach(RelicItemSlot relicSlot in relicSlots){
            if (relicSlot.Item != null && relicSlot.Item.demonType == demonType){
                associatedRelicSlot = relicSlot;
                break;
            }
        }
        associatedRelicSlot.SetHPActive();

        aIPath.maxSpeed = this.speed;
        aIDestination.target = player.transform;
    }

    // Update is called once per frame
    protected override void Update()
    {
        UpdateAnimationValues();
        if(this.isDead) Dead();
    }

    public override void Hit(int damage){
        base.Hit(damage);
        this.TakeDamage(damage);
        float percentage = (float)this.currentHealth / this.health;
        associatedRelicSlot.UpdateHP(percentage);
    }

    public override void Dead(){
        // TODO create death animation
        associatedRelicSlot.SetHPInactive();
        Destroy(this.gameObject);
    }
}
