using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spellbook : MonoBehaviour
{
    
    public void CastPoisonNova(GameObject b, Transform firePoint, Collider2D playerCollider, float spellForce)
    {   
        for (int i = 0; i < 6; i++)
        {
            firePoint.Rotate(Vector3.forward * (i*45));
            GameObject spell = Instantiate(b, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = spell.GetComponent<Rigidbody2D>();
            Physics2D.IgnoreCollision(spell.GetComponent<Collider2D>(), playerCollider);

            // Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            // Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            // Vector2 lookDir = worldPosition - rb.position;

            rb.AddForce(Vector2.up * spellForce, ForceMode2D.Impulse);
        }

    }
}
