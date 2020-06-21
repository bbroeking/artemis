using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spellbook : MonoBehaviour
{
    public void PoisonNova(GameObject b, Transform firePoint, Collider2D playerCollider)
    {   
        float force = 4f;
        for (int i = 0; i < 6; i++)
        {
            GameObject spell = Instantiate(b, firePoint.position, Quaternion.identity);
            Destroy(spell, 3);
            Rigidbody2D rb = spell.GetComponent<Rigidbody2D>();
            Physics2D.IgnoreCollision(spell.GetComponent<Collider2D>(), playerCollider);
            rb.AddForce((Quaternion.Euler(0, 0, (60f*i)) * Vector2.up) * force, ForceMode2D.Impulse);
        }
    }

    public void GravityField(GameObject b, Transform firePoint, Collider2D playerCollider){

    }
}
