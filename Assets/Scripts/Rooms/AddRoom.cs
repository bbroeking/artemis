﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    private RoomTemplate templates;
    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("rooms").GetComponent<RoomTemplate>();
        templates.rooms.Add(this.gameObject);
    }
}
