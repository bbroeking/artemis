using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : Projectile
{
    protected override void Start() {
        base.Start();
        SetVectorDirection();
        pos = player.transform.position;
    }
    protected override void Update(){
        base.Update();
    }
    protected override void OnEnable(){
        base.OnEnable();
        if (player != null) {
            pos = player.transform.position;
            SetVectorDirection();
        }
        else Debug.LogWarning("Not setting new position due to null player object");
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.enemy)) {
            collision.gameObject.GetComponent<Enemy>()?.Hit(5);
        }
        gameObject.SetActive(false);
    }
    private void SetVectorDirection(){
        direction = player.GetShotDirection();
    }
}
