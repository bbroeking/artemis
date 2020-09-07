﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum EnemyType {
    Melee,
    Ranged,
    Patrol
}
public class Spawner : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    private GameObject enemy;
    private GameObject parent;
    private GameObject enemyInstance;
    private EnemyType enemyType;
    public Sprite sprite;

    void Awake(){
        enemy = null;
        parent = null;
        var random = new System.Random();
        // Pick Enemy Type
        int choice = random.Next(Enum.GetNames(typeof(EnemyType)).Length);
        enemyType = (EnemyType) choice;
        LoadEnemy();
        // Pick Sprite
        int index = random.Next(sprites.Length);
        sprite = sprites[index];
    }
    void Start()
    {
        if (parent != null){
            GameObject parentOfEnemyGameObject = Instantiate(parent, transform.position, Quaternion.identity);
            enemyInstance = parent.transform.GetChild(0).gameObject;
            parentOfEnemyGameObject.transform.SetParent(transform);
        }
        else {
            enemyInstance = Instantiate(enemy, transform.position, Quaternion.identity);
            enemyInstance.transform.SetParent(transform);
        }
        SpriteRenderer sr = enemyInstance.GetComponent<SpriteRenderer>();
        sr.sprite = sprite;
        Enemy e = enemyInstance.GetComponent<Enemy>();
        e.spawnLocation = transform;
    }

    void LoadEnemy(){
        if (EnemyType.Melee == enemyType){
            enemy = (GameObject) LoadPrefab.LoadPrefabFromFile("Enemies/Slime/Melee");
        }
        else if (EnemyType.Ranged == enemyType){
            enemy = (GameObject) LoadPrefab.LoadPrefabFromFile("Enemies/Slime/Ranged");
        }
        else if (EnemyType.Patrol == enemyType){
            parent = (GameObject) LoadPrefab.LoadPrefabFromFile("Enemies/Slime/Patrol");
        }
    }
}