using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwing : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag(Tags.enemy)){
            collision.GetComponent<Enemy>()?.Hit(5);
        }
    }
}
