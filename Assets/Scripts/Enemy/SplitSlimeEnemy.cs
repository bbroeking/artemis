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
        if(activeSlimes != 0) return;
        base.SpawnLoot();

    }
    public override void Hit(int damage)
    {
        base.Hit(damage);
        if (this.isDead) activeSlimes -= 1;
    }
}
