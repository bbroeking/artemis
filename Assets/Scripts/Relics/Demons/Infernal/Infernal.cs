using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Infernal : Character, ISummonable
{
    protected Player player;

    public void Summon(Player player)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        player = PlayerSingleton.Instance.player;
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }
}
