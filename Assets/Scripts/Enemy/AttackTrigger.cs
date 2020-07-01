using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    [SerializeField] Attack attack;
    [SerializeField] CircleCollider2D col;
    [SerializeField] float attackRange = 1f;
    void OnValidate(){
        col = GetComponent<CircleCollider2D>();
        col.radius = attackRange;
    }
    void Awake(){
        attack = GetComponentInParent<Attack>();
    }
    void OnTriggerEnter2D(){
        attack.IsInRange = true;
    }

    void OnTriggerExit2D(){
       attack.IsInRange = false;
    }
}
