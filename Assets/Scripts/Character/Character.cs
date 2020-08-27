using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Character")]
    public int health;
    protected int currentHealth;
    public int CurrentHealth { get { return currentHealth;} }
    public int speed; 
    protected int baseDamage;
    public int BaseDamage { get { return baseDamage;} }
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
    private int spellDamage;
    public int SpellDamage { get { return spellDamage; } }
    protected bool isDead;
    protected bool isDamageDisabled;
    protected float disableDamageDuration = 0.75f;

    protected virtual void Awake(){
        currentHealth = health;
        speed  = 6;
        baseDamage = 1;
        mainHandMaxDamage = 1;
        mainHandMinDamage = 1;
        strengthModifier = 0.1f;
        dexterityModifier  = 0.1f;
        intellectModifier = 0.1f;
        vitalityModifier = 0;
        internalAttackCooldown = 0.5f;
        spellDamage = 1;
        isDead = false;
        isDamageDisabled = false;
    }

    protected virtual void Start(){}
    protected virtual void Update(){}

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
    protected void CalculateSpellDamage(){
        this.spellDamage = 1 + (int)this.intellect.Value;
    }
    protected void UpdateModifiers(){
        CalculateBaseHealth();
        CalculateInteralAttackCD();
        CalculateSpellDamage();
    }
    public float percentHealth(){
        return (float)currentHealth / (float)health;
    }

    public virtual void Hit(int damage){
        return;
    }
    
    public IEnumerator DisableDamage(float time){
        isDamageDisabled = true;
        yield return new WaitForSeconds(time);
        isDamageDisabled = false;
    }
    public virtual void TakeDamage(int damage){
        if (isDamageDisabled) return;
        StartCoroutine(DisableDamage(disableDamageDuration));
        this.currentHealth -= damage;
        if(this.currentHealth <= 0) this.isDead = true;
    }

    public virtual void Dead(){
        return;
    }
}
