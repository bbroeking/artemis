using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RelicType {Fang, Nova};
public class Spellbook : MonoBehaviour
{
    [SerializeField] Collider2D playerCollider;

    [Header("Projectiles")]
    [SerializeField] GameObject projectilePrefab;

    // Demons
    [SerializeField] public Imp Imp;
    [SerializeField] public VoidGuardian VoidGuardian;
    [SerializeField] public Infernal Infernal;

    public void PoisonNova(Transform firePoint)
    {   
        for (int i = 0; i < 6; i++)
        {
            GameObject projectileGameObject = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
            
            Projectile projectile = projectileGameObject.GetComponent<Projectile>();
            projectile.ZRotation = 60f*i;

            ProjectileHelpers.ObjectIgnores(projectileGameObject, playerCollider);
            Destroy(projectileGameObject, 3);
        }
    }

    public void GravityField(GameObject b, Transform firePoint, Collider2D playerCollider){

    }

}
