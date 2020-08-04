using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Sprite[] sprites;
    public Sprite sprite;

    void OnValidate(){
        enemy = (GameObject) LoadPrefab.LoadPrefabFromFile("Enemies/MeleeEnemy");
    }
    void Awake(){
        var random = new System.Random();
        int index = random.Next(sprites.Length);
        sprite = sprites[index];
    }
    void Start()
    {
        GameObject enemyInstance = Instantiate(enemy, transform.position, Quaternion.identity);
        enemyInstance.transform.SetParent(transform);
        SpriteRenderer sr = enemyInstance.GetComponent<SpriteRenderer>();
        sr.sprite = sprite;
        Enemy e = enemyInstance.GetComponent<Enemy>();
        e.spawnLocation = transform;
    }
}
