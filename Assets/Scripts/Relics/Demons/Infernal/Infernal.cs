using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Infernal : Demon, ISummonable
{

    public void Summon(Player player)
    {
        string pathToPrefab = "Singletons/Demons/InfernalSingleton";
        GameObject demon = (GameObject) LoadPrefab.LoadPrefabFromFile(pathToPrefab);
        Instantiate(demon, player.transform.position, Quaternion.identity);
        player.Infernal = this;
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
