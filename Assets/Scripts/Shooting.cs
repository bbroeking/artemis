using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform primary;
    public Transform secondary;
    public GameObject sniperBullet;
    public GameObject gravityBullet;
    public Collider2D playerCollider;

    public float bulletForce = 200f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot(sniperBullet, primary);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Shoot(gravityBullet, secondary);
        }
    }

    void Shoot(GameObject b, Transform firePoint)
    {
        GameObject bullet = Instantiate(b, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), playerCollider);
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        if (movement.y <= 0 && (Mathf.Abs(movement.y) > Mathf.Abs(movement.x) || movement.y + movement.x == 0 ||  movement.y + movement.x == -2))
        {
            rb.AddForce(-firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
        else if(movement.x > 0 && Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
        {
            rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        } 
        else if (movement.x < 0 && Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
        {
            rb.AddForce(-firePoint.right * bulletForce, ForceMode2D.Impulse);
        }
        else if (movement.y > 0 && Mathf.Abs(movement.y) >= Mathf.Abs(movement.x))
        {
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
    }
}
