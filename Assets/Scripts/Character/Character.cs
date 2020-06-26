using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int health;
    public int currentHealth;
    protected int speed; 
    public CharacterStat strength;
    public CharacterStat dexterity;
    public CharacterStat intellect;
    public CharacterStat vitality;
    protected int mainHandMinDamage;
    protected int mainHandMaxDamage;
    protected float strengthModifier;
    protected float dexterityModifier;
    protected float intellectModifier;
    protected float vitalityModifier;
    protected float internalAttackCooldown;
    public float InteralAttackCooldown { get { return internalAttackCooldown;} }
    public int spellDamage;
    protected bool dead;

    protected virtual void Awake(){
        health = 30;
        currentHealth = health;
        speed  = 6;
        mainHandMaxDamage = 1;
        mainHandMinDamage = 1;
        strengthModifier = 0.1f;
        dexterityModifier  = 0.1f;
        intellectModifier = 0.1f;
        vitalityModifier = 0;
        internalAttackCooldown = 2f;
        dead = false;
    }

    public int CalculateDamage(){
        int damageRoll = Random.Range(mainHandMinDamage, mainHandMaxDamage);
        float damageCalc = (float)damageRoll * ((float)strength.BaseValue * strengthModifier);
        return (int)Mathf.Ceil(damageCalc);
    }

    protected void CalculateBaseHealth(){
        float healthCalc = 30f + 30f * ((float)vitality.BaseValue * vitalityModifier);
        this.health = (int)Mathf.Ceil(healthCalc);
    }

    protected void CalculateInteralAttackCD(){
        this.internalAttackCooldown = 2f * ((float)dexterity.BaseValue * dexterityModifier);
    }

    public Dictionary<string, dynamic> GetCharacterStats(){
        Dictionary<string, dynamic> characterStats = new Dictionary<string, dynamic>();
        characterStats.Add("health", this.health);
        characterStats.Add("speed", this.speed);
        // characterStats.Add("strength", this.strength);
        // characterStats.Add("dexterity", this.dexterity);
        // characterStats.Add("intellect", this.intellect);
        // characterStats.Add("vitality", this.vitality);
        characterStats.Add("mainHandMaxDamage", this.mainHandMaxDamage);
        characterStats.Add("mainHandMinDamage", this.mainHandMinDamage);
        characterStats.Add("strengthModifier", this.strengthModifier);
        characterStats.Add("dexterityModifier", this.dexterityModifier);
        characterStats.Add("intellectModifer", this.intellectModifier);
        characterStats.Add("vitalityModifier", this.vitalityModifier);
        characterStats.Add("internalAttackCooldown", this.internalAttackCooldown);
        return characterStats;
    }

    public float percentHealth(){
        return (float)currentHealth / (float)health;
    }
}
