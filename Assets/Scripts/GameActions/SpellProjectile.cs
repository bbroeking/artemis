using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellProjectile : MonoBehaviour
{
    [SerializeField] private Player player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>()?.Hit(1);
        }
        Destroy(gameObject);
    }
}
