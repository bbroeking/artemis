using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour
{
    private Player player;
    void Start()
    {
        player = FindObjectOfType<Player>();
        player.transform.position = transform.position;
    }
}
