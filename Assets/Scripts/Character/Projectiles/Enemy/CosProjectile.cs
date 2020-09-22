 using UnityEngine;
 using System.Collections;
 
public class CosProjectile : Projectile {
     public float frequency = 5.0f;  // Speed of sine movement
     public float magnitude = 0.7f;   // Size of sine movement
     private Vector3 axis;
 
     protected override void Start() {
          base.Start();
          pos = transform.position;
          axis = Vector3.down;  // May or may not be the axis you want
     }
     
     protected override void Update() {
          pos += Quaternion.Euler(xRotation, yRotation, zRotation) * transform.up * Time.deltaTime * bulletSpeed;
          transform.position = pos + axis * Mathf.Cos(Time.time*frequency) * magnitude;
     }
     public override void Init(float startingAngle, float spinRate,
                             float bulletSpeed, float bulletAcceleration,
                             int damage, Vector3 position,
                             float frequency, float magnitude, Vector3 target){
        this.zRotation = startingAngle;
        this.spinRate = spinRate;
        this.bulletSpeed = bulletSpeed;
        this.bulletAcceleration = bulletAcceleration;
        this.damage = damage;
        this.pos = position;
        this.frequency = frequency;
        this.magnitude = magnitude;
    }
}