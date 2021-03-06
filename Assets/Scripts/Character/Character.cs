﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

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
    protected float internalAttackCooldown;
    public float InteralAttackCooldown { get { return internalAttackCooldown;} }
    protected bool isDead;
    protected bool isDamageDisabled;
    protected float disableDamageDuration = 0.75f;
    [SerializeField] protected AIPath aIPath;
    [SerializeField] protected Animator anim;

    protected virtual void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = health;
        baseDamage = 1;
        internalAttackCooldown = 0.5f;
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
    protected virtual void UpdateAnimationValues(){
        Vector3 velo = aIPath.velocity;
        anim.SetFloat("Horizontal", velo.x);
        anim.SetFloat("Vertical", velo.y);
        anim.SetFloat("Magnitude", velo.magnitude);

        if (velo.x != 0.0f || velo.y != 0.0f){
            anim.SetFloat("LastHorizontal", velo.x);
            anim.SetFloat("LastVertical", velo.y);
        }
    }
    public virtual void Dead(){
        Debug.LogWarning("Dead funciton is not implemented for object");
    }
}
