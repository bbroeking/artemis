using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenomFangProjectile : Projectile
{
    private float speed = 10f;
    protected override void Start(){}
    protected override void Update(){}
    void FixedUpdate()
    {
         // Calculate direction vector
         Vector3 dir = this.transform.position - target;
         // Normalize resultant vector to unit Vector
         dir = dir.normalized;
         // Move in the direction of the direction vector every frame 
         this.transform.position += dir * Time.deltaTime * speed;

         if (this.transform.position == target) TriggerDestruction();
    }
    protected override void OnEnable(){}
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.enemy)) {
            collision.gameObject.GetComponent<Enemy>()?.Hit(5);
        }
        gameObject.SetActive(false);
    }
}
