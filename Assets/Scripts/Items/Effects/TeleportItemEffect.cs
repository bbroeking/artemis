﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Item Effects/Teleport")]

public class TeleportItemEffect : UsableItemEffect
{
    public override void ExecuteEffect(UsableItem parentItem, Player player)
    {
        Debug.Log(player.transform.position.ToString());
        player.LastDungeonLocation = player.transform.position;
        player.scene = SceneManager.GetActiveScene().name;
        Debug.Log(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Home");
    }

    public override string GetDescription()
    {
        return "Teleports the user home";
    }
}
