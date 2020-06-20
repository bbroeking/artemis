﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellProjectile : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null){
                enemy.Hit();
            }
        }
        else if (collision.gameObject.tag == "projectile"){
            Debug.Log("Ignore Projectile Collision");
        }
        else{
            Destroy(gameObject);
        }
    }
}
