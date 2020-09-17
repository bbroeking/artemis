using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    protected Attack attack;
    [SerializeField] protected GameObject target;
    [SerializeField] protected CircleCollider2D col;
    [SerializeField] float attackTriggerRange = 1f;
    void OnValidate(){
        col = GetComponent<CircleCollider2D>();
        col.radius = attackTriggerRange;
    }
    void Start(){
        attack = GetComponentInParent<Attack>();
    }
    void OnTriggerEnter2D(Collider2D collision){
        attack.IsInRange = true;
        attack.targetInRange = collision.gameObject.transform;
    }

    void OnTriggerExit2D(Collider2D collision){
       attack.IsInRange = false;
       attack.targetInRange = null;
    }
}
