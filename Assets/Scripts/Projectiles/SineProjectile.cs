 using UnityEngine;
 using System.Collections;
 
public class SineProjectile : Projectile {
    public float MoveSpeed = 2.0f;
    public float frequency = 5.0f;  // Speed of sine movement
    public float magnitude = 0.7f;   // Size of sine movement
    private Vector3 axis;
    private Vector3 pos;
 
    protected override void Start () {
        base.Start();
        pos = transform.position;
        axis = Vector3.down;  // May or may not be the axis you want
    }
     
    protected override void Update() {
        pos += Quaternion.Euler(xRotation, yRotation, zRotation) * transform.up * Time.deltaTime * MoveSpeed;
        transform.position = pos + axis * Mathf.Sin(Time.time*frequency) * magnitude;
    }
}