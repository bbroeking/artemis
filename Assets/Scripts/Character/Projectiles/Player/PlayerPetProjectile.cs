using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPetProjectile : Projectile
{
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update(){}
    void FixedUpdate()
    {
         // Calculate direction vector
         Vector3 dir = target;
         // Normalize resultant vector to unit Vector
         dir = dir.normalized;
         // Move in the direction of the direction vector every frame 
         this.transform.position += dir * Time.deltaTime * bulletSpeed;

         if (this.transform.position == target) TriggerDestruction();
    }
    protected override void OnEnable(){
        base.OnEnable();
        if (player != null) {
            if (player.Imp != null) pos = player.Imp.transform.position;
            else if (player.VoidGuardian != null) pos = player.VoidGuardian.transform.position;
            else if (player.Infernal != null) pos = player.Infernal.transform.position; 
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
}
