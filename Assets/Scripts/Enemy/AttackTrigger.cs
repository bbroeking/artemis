using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    [SerializeField] Attack attack;
    void OnValidate(){
        attack = GetComponentInParent<Attack>();
    }
    void OnTriggerEnter2D(){
        attack.IsInRange = true;
    }

    void OnTriggerExit2D(){
       attack.IsInRange = false;
    }
}
