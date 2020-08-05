using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellProjectile : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.enemy))
        {
            collision.gameObject.GetComponent<Enemy>()?.Hit(1);
        }
        Destroy(gameObject);
    }
}
