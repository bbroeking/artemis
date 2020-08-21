using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHelpers : MonoBehaviour
{
    public static void ObjectIgnores(GameObject gameObject, Collider2D collider2D){
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collider2D);
    }
}
