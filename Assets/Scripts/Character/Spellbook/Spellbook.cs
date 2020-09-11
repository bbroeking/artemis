using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RelicType {Fang, Nova, Beam};
public class Spellbook : MonoBehaviour
{
    private Player player;
    [SerializeField] Collider2D playerCollider;

    [Header("Projectiles")]
    [SerializeField] GameObject projectilePrefab;

    [Header("Demons")]
    [SerializeField] public Imp Imp;
    [SerializeField] public VoidGuardian VoidGuardian;
    [SerializeField] public Infernal Infernal;

    [Header("Venom")]
    [SerializeField] VenomBeam venomBeam;
    private float poisonBeamDuration = 300f;

    void Start(){
        player = PlayerSingleton.Instance.player;
    }

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

    public void PoisonFang(Transform firePoint){

    }

    public void PoisonBeam(Transform firePoint, MoveDirection dir){
        Vector3 vec = ProjectileHelpers.moveDirectionToNormalVector(dir);
        venomBeam.EnableBeam(firePoint, vec);
        StartCoroutine(Duration(poisonBeamDuration));
    }
    private IEnumerator Duration(float cd)
    {
        yield return new WaitForSeconds(cd);
        venomBeam.DisableBeam();
    }

}
