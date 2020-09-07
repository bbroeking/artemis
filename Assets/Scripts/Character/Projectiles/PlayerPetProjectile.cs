using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPetProjectile : Projectile
{
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.enemy)) {
            collision.gameObject.GetComponent<Enemy>()?.Hit(5);
        }
        gameObject.SetActive(false);
    }
}
