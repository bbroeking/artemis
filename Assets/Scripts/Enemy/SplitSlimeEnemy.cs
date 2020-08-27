using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitSlimeEnemy : Enemy
{
    public static int activeSlimes;

    protected override void Start(){
        base.Start();
        activeSlimes++;
    }

    public override void SpawnLoot(){
        activeSlimes -= 1;
        if(activeSlimes == 0) base.SpawnLoot();
    }
    public override void Hit(int damage)
    {
        base.Hit(damage);
    }
}
