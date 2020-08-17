using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] protected Player player;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected float force = 10f;
    protected int damage = 1;
    public int Damage { get { return damage;} set { damage = value; }}
    protected float xRotation = 0f;
    public float XRotation { get { return xRotation; } set {xRotation = value;} }
    protected float yRotation = 0f;
    public float YRotation { get { return yRotation; } set { yRotation = value;}}
    protected float zRotation = 0f;
    public float ZRotation { get {return zRotation; } set {zRotation = value;}}

    protected virtual void Start(){
        player = SingletonPlayer.Instance.player;
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3);
    }

    protected virtual void Update(){
        Vector3 vec = (player.transform.position - transform.position).normalized;
        rb.AddForce(Vector3.up * force, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag(Tags.player)){
            player.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
