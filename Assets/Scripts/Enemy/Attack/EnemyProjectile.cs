using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : SpellProjectile
{
    [SerializeField] private Player player;
    private int damage;
    public int Damage { get { return damage;} set { damage = value; }}

    void Start(){
        player = SingletonPlayer.Instance.player;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag(Tags.player)){
            player.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
