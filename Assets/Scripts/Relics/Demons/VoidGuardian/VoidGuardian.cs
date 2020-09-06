using UnityEngine;
using Pathfinding;
public class VoidGuardian : Demon, ISummonable
{
    private VoidZone voidZone;
    public bool isZoneDepleted;

    public void Summon(Player player)
    {
        string pathToPrefab = "Singletons/Demons/VoidGuardianSingleton";
        GameObject demon = (GameObject) LoadPrefab.LoadPrefabFromFile(pathToPrefab);
        Instantiate(demon, player.transform.position, Quaternion.identity);
        player.VoidGuardian = this;
    }

    protected override void Start()
    {
        base.Start();
        voidZone = GetComponentInChildren<VoidZone>();
    }

    protected override void Update()
    {
        base.Update();
        if (isZoneDepleted) voidZone.gameObject.SetActive(false);
    }
}
