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
    [SerializeField] string venomFangPrefabPath = "Projectiles/PlayerProjectiles/VenomFangProjectile";
    private float poisonBeamDuration = 4f;
    private int numOfFangs = 3;

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
        if (player.lastMoveDirection == MoveDirection.Up ||
            player.lastMoveDirection == MoveDirection.Down){
            Vector2 offset = new Vector2(0.5f, 0);
            StartCoroutine(SpawnFangsWithOffset((Vector2)firePoint.position, offset, player.lastMoveDirection));
        }
        else {
            Vector2 offset = new Vector2(0, 0.5f);
            StartCoroutine(SpawnFangsWithOffset((Vector2)firePoint.position, offset, player.lastMoveDirection));
        }
    }

    private IEnumerator SpawnFangsWithOffset(Vector2 position, Vector2 offset, MoveDirection moveDirection){
        for(int fangs = 0; fangs < numOfFangs; fangs++){
            SpawnFang(position + offset, moveDirection);
            SpawnFang(position - offset, moveDirection);
            yield return new WaitForSeconds(0.25f);
        }
        yield return new WaitForSeconds(0.25f);
    }
    
    public void SpawnFang(Vector2 position, MoveDirection moveDirection){
        GameObject prefab = (GameObject) LoadPrefab.LoadPrefabFromFile("Projectiles/PlayerProjectiles/VenomFangProjectile");
        GameObject GO = Instantiate(prefab, position, Quaternion.identity);
        GO.GetComponent<VenomFangProjectile>().target = player.transform.position - ProjectileHelpers.moveDirectionToNormalVector(moveDirection);
        GO.SetActive(true);
    }

    public void PoisonBeam(Transform firePoint){
        venomBeam.EnableBeam(firePoint);
        StartCoroutine(Duration(poisonBeamDuration));
    }
    private IEnumerator Duration(float cd)
    {
        yield return new WaitForSeconds(cd);
        venomBeam.DisableBeam();
    }

}
