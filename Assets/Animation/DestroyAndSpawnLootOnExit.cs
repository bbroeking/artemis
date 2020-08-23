using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndSpawnLootOnExit : StateMachineBehaviour
{
    private Enemy enemy;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
        enemy = animator.GetComponent<Enemy>();
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        enemy.SpawnLoot();
        Destroy(animator.gameObject);
    }
}
