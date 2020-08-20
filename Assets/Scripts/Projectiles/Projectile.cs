﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] protected Player player;
    [SerializeField] protected Rigidbody2D rb;
    protected Vector3 pos;
    protected Vector3 direction;
    public float MoveSpeed = 2.0f;
    protected int damage = 1;
    protected float duration = 3.0f;
    public int Damage { get { return damage;} set { damage = value; }}
    protected float xRotation = 0f;
    public float XRotation { get { return xRotation; } set {xRotation = value;} }
    protected float yRotation = 0f;
    public float YRotation { get { return yRotation; } set { yRotation = value;}}
    protected float zRotation = 0f;
    public float ZRotation { get {return zRotation; } set {zRotation = value;}}

    protected virtual void Start(){
        player = PlayerSingleton.Instance.player;
        pos = transform.position;
        direction = transform.right; // TODO don't default to up
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, duration);
    }
    protected virtual void Update(){
        pos += direction * Time.deltaTime * MoveSpeed;
        transform.position = pos;
    }
    protected virtual void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag(Tags.player)){
            player.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
    public virtual void SetDirection(Vector3 direction){
        this.direction = direction;
    }
}
