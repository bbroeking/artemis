using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Loot", menuName = "Loot")]
public class Loot : ScriptableObject
{
    public int rechargeTime;
    public int maxDamage;
    public int minDamage;

    public Sprite sprite;

}
