using UnityEngine;

public class AggroTrigger : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    [SerializeField] CircleCollider2D col;
    [SerializeField] float aggroRange = 1f;
    void OnValidate(){
        col = GetComponent<CircleCollider2D>();
        col.radius = aggroRange;
    }
    void Awake(){
        enemy = GetComponentInParent<Enemy>();
    }
    void OnTriggerEnter2D(){
        enemy.IsInAggroRange = true;
    }
    void OnTriggerStay2D(){
        enemy.IsInAggroRange = true;
    }
    void OnTriggerExit2D(){
       enemy.IsInAggroRange = false;
    }
}
