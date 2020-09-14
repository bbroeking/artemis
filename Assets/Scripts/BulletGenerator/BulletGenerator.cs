using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProjectileType {
    HellfireProjectile,
    HellfirePetProjectile,
    VoidProjectile,
    VoidPetProjectile,
    PoisonProjectile,
    PoisonPetProjectile,
    Projectile,
    SineProjectile,
    CosProjectile,
}
public class BulletGenerator : Attack
{
    [Header("Bullet Generator")]
    public ProjectileType projectileType;
    public int damage;

    [Header("Movement")]
    public int totalBulletArrays;
    public int bulletsPerArray;
    public float bulletArraySpread;
    public float bulletSpread;
    public float startingAngle;
    public float spinRate;
    public float bulletSpeed;
    public float bulletAcceleration;

    [Header("Sine/Cosine")]
    public float frequency;
    public float magnitude;

    protected override void TriggerAttack()
    {
        for (int array=0; array < totalBulletArrays; array++){
            for(int bullets=0; bullets < bulletsPerArray; bullets++){
                GameObject GO = ObjectPooler.SharedInstance.GetPooledObject((int) projectileType);
                Projectile projectile = GO.GetComponent<Projectile>();
                float rotation = startingAngle + bullets*bulletSpread + array*bulletArraySpread;
                projectile.Init(rotation, spinRate, bulletSpeed,
                                bulletAcceleration, damage, this.transform.position,
                                frequency, magnitude);
                GO.SetActive(true);
            }
        }
    }


}
