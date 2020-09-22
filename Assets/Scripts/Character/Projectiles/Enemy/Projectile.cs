using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] protected Player player;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected Animator animator;
    protected Vector3 pos = Vector3.zero;
    protected Vector3 direction = Vector3.up;
    public Vector3 target;
    public Vector3 Direction { get { return direction;} set { direction = value; }}
    protected int damage = 1;
    protected float duration = 3.0f;
    public int Damage { get { return damage;} set { damage = value; }}
    protected float xRotation = 0f;
    public float XRotation { get { return xRotation; } set {xRotation = value;} }
    protected float yRotation = 0f;
    public float YRotation { get { return yRotation; } set { yRotation = value;}}
    protected float zRotation = 0f;
    public float ZRotation { get {return zRotation; } set {zRotation = value;}}
    public float bulletSpeed = 2.0f;
    public float spinRate = 0.0f;
    public float bulletAcceleration = 0.0f;


    protected virtual void Start(){
        player = PlayerSingleton.Instance.player;
        pos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    protected virtual void OnEnable(){
        transform.position = pos;
        Invoke("TriggerDestruction", duration);
    }

    protected virtual void Update(){
        pos += Quaternion.Euler(xRotation, yRotation, zRotation) * direction 
                * Time.deltaTime * bulletSpeed;
        bulletSpeed += Time.deltaTime * bulletSpeed;
        zRotation += Time.deltaTime * spinRate;
        transform.position = pos;
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag(Tags.player) ||
           collision.gameObject.CompareTag(Tags.imp) ||
           collision.gameObject.CompareTag(Tags.infernal) || 
           collision.gameObject.CompareTag(Tags.voidGuardian))
        {
            collision.gameObject.GetComponent<Character>().Hit(damage);
        }
        if(collision.gameObject.CompareTag(Tags.voidZone)){
            collision.gameObject.GetComponent<VoidZone>().RemoveVoidEnergy(damage);
        }
        gameObject.SetActive(false);
    }

    public virtual void SetDirection(Vector3 direction){
        this.direction = direction;
    }

    protected virtual void TriggerDestruction(){
        animator.SetBool("Expired", true);
    }

    public virtual void Init(float startingAngle, float spinRate,
                             float bulletSpeed, float bulletAcceleration,
                             int damage, Vector3 position,
                             float frequency, float magnitude, Vector3 target){
        this.zRotation = startingAngle;
        this.spinRate = spinRate;
        this.bulletSpeed = bulletSpeed;
        this.bulletAcceleration = bulletAcceleration;
        this.damage = damage;
        this.pos = position;
        this.target = target;
    }
}
