using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected int health;
    protected int speed; 
    protected int strength;
    protected int dexterity;
    protected int intellect;
    protected int vitality;
    protected int mainHandMinDamage;
    protected int mainHandMaxDamage;
    protected int strengthModifier;

    private void Awake(){
        speed  = 6;
        health = 30;
        strength = 0;
        dexterity = 0;
        intellect = 0;
        vitality = 0;
    }

    public int CalculateDamage(){
        int damageRoll = Random.Range(mainHandMinDamage, mainHandMaxDamage);
        return damageRoll * (strength * strengthModifier);
    }

    public void PrintStats(){
        Debug.Log("Health " + health);
        Debug.Log("Strength: " + strength);
        Debug.Log("MainHandMaxDamage" + mainHandMaxDamage);
    }
}
