using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHelpers : MonoBehaviour
{
    public static void ObjectIgnores(GameObject gameObject, Collider2D collider2D){
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collider2D);
    }
    public static System.Random random = new System.Random();
    public static List<Vector3> directions = new List<Vector3>{Vector3.up, Vector3.down, Vector3.right, Vector3.left};
    public static Vector3 GenerateRandomOffset(){
        return Quaternion.Euler(random.Next(0, 360), random.Next(0, 360), random.Next(0, 360)) *directions[random.Next(0,4)];
    }

    public static Vector3 moveDirectionToNormalVector(MoveDirection dir){
        if (dir == MoveDirection.Up) return Vector3.up;
        if (dir == MoveDirection.Down) return Vector3.down;
        if (dir == MoveDirection.Right) return Vector3.right;
        if (dir == MoveDirection.Left) return Vector3.left;
        Debug.LogWarning("Did not pass a valid cardinal direction, returning zero vector");
        return Vector3.zero;
    }
}
