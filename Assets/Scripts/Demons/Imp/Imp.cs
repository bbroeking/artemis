using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Imp : Character, ISummonable
{
    [Header("Imp")]
    [SerializeField] protected AIDestinationSetter aIDestination;
    [SerializeField] protected AIPath aIPath;
    protected Player player;
    protected override void Start()
    {
        player = PlayerSingleton.Instance.player;
        aIDestination = GetComponent<AIDestinationSetter>();
        aIPath = GetComponent<AIPath>();

        aIPath.maxSpeed = this.speed;
        aIDestination.target = player.transform;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if(this.isDead) Dead();
    }

    public override void Hit(int damage){
        base.Hit(damage);
        this.TakeDamage(damage);
    }

    public override void Dead(){
        // TODO create death animation
        Destroy(this.gameObject);
    }

    public void Summon(Player player)
    {
        string pathToPrefab = "Singletons/Demons/ImpSingleton";
        GameObject demon = (GameObject) LoadPrefab.LoadPrefabFromFile(pathToPrefab);
        Instantiate(demon, player.transform.position, Quaternion.identity);
        player.Imp = this;
    }

}
