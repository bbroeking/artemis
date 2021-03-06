﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imp : Demon, ISummonable
{
    protected override void Start()
    {
        base.Start();
        demonType = DemonType.Imp;
    }
    protected override void Update()
    {
        base.Update();
    }

    public void Summon(Player player)
    {
        string pathToPrefab = PrefabPath.ImpSingleton;
        GameObject demon = (GameObject) LoadPrefab.LoadPrefabFromFile(pathToPrefab);
        Instantiate(demon, player.transform.position, Quaternion.identity);
        player.Imp = this;
    }

}
