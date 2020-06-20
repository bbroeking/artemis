using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spellbook : MonoBehaviour
{
    
    public void CastPoisonNova(GameObject b, Transform firePoint, Collider2D playerCollider)
    {   
        float force = 4f;
        for (int i = 0; i < 6; i++)
        {
            GameObject spell = Instantiate(b, firePoint.position, Quaternion.identity);
            Rigidbody2D rb = spell.GetComponent<Rigidbody2D>();
            Physics2D.IgnoreCollision(spell.GetComponent<Collider2D>(), playerCollider);
            rb.AddForce((Quaternion.Euler(0, 0, (60f*i)) * Vector2.up) * force, ForceMode2D.Impulse);
        }

    }
}
