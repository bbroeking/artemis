using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWaveProjectile : PlayerProjectile
{
    [SerializeField] Animator animator;
    private MoveDirection moveDirection; 

    protected override void Start(){
        player = PlayerSingleton.Instance.player;
        // Get the direction to send the player generated projectile if only Up, Down, Left, Right
        moveDirection = player.GetMoveDirection();
        SetVectorDirection();
        pos = player.castPos.position;
        MoveSpeed = 14.0f;
        rb = GetComponent<Rigidbody2D>();
        animator.Play("MeleeWave"); // don't call Destroy(), we destroy on the animation exit
    }
    private void SetVectorDirection(){
        if (moveDirection == MoveDirection.Up){
            direction = Vector3.up;
        }
        else if(moveDirection == MoveDirection.Down){
            this.gameObject.transform.Rotate(180f, 0f, 0f, Space.World);
            direction = Vector3.down;
        }
        else if(moveDirection == MoveDirection.Left){
            this.gameObject.transform.Rotate(0f, 0f, 90f, Space.World);
            direction = Vector3.left;
        }
        else if(moveDirection == MoveDirection.Right){
            this.gameObject.transform.Rotate(0f, 0f, -90f, Space.World);
            direction = Vector3.right;
        }
    }
}
