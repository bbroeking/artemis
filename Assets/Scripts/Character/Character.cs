using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Character")]
    [SerializeField] SpriteRenderer spriteRenderer;
    public int health;
    [SerializeField] protected int currentHealth;
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
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = health;
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
    public float percentHealth(){
        return (float) currentHealth / (float) health;
    }
    public virtual void Hit(int damage){
        Debug.LogWarning("Hit funciton is not implemented for object");
    }
    public virtual void TakeDamage(int damage){
        Debug.Log(damage.ToString());
        if (isDamageDisabled) return;
        StartCoroutine(DisableDamage(disableDamageDuration));
        this.currentHealth -= damage;
        if(this.currentHealth <= 0) this.isDead = true;
    }
    public IEnumerator DisableDamage(float time){
        isDamageDisabled = true;
        yield return new WaitForSeconds(time);
        isDamageDisabled = false;
    }
    public virtual void Dead(){
        Debug.LogWarning("Dead funciton is not implemented for object");
    }
}
