using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Split_Boss : StateMachineBehaviour
{
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject enemy = (GameObject) LoadPrefab.LoadPrefabFromFile("Enemies/Slime/Boss/SplitRanged");
        Instantiate(enemy, animator.transform.position + ProjectileHelpers.GenerateRandomOffset(), animator.transform.rotation);
        Instantiate(enemy, animator.transform.position + ProjectileHelpers.GenerateRandomOffset(), animator.transform.rotation);
    }
}
