using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenomBeam : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] BoxCollider2D box;
    Vector3 dir;
    private Transform firePoint;
    private bool updateBeam;
    private Player player;

    public GameObject startVFX;
    public GameObject endVFX;
    private List<ParticleSystem> particles = new List<ParticleSystem>();

    private int venomBeamDamage= 1;
    
    void Start()
    {
        player = PlayerSingleton.Instance.player;
        FillLists();
        DisableBeam();
    }

    void Update()
    {
        if (updateBeam) UpdateBeam();
    }

    public void EnableBeam(Transform firePoint){
        // Enable Objects 
        lineRenderer.enabled = true;
        box.enabled = true;

        this.firePoint = firePoint;
        updateBeam = true;

        for(int i = 0; i<particles.Count; i++)
            particles[i].Play();
    }

    private void UpdateBeam(){
        dir = ProjectileHelpers.moveDirectionToNormalVector(player.lastMoveDirection);
        RaycastHit2D hit = Physics2D.Raycast((Vector2) firePoint.position, dir, Mathf.Infinity, 1 << LayerMask.NameToLayer("walls"));
        lineRenderer.SetPosition(0, (Vector2) firePoint.position);
        startVFX.transform.position = (Vector2) firePoint.position;

        lineRenderer.SetPosition(1, (Vector2) hit.point);
        endVFX.transform.position = (Vector2) hit.point;

        SetBoxCollider(firePoint.position, hit.point);
    }

    public void DisableBeam(){
        // Disable Objects
        lineRenderer.enabled = false;
        box.enabled = false;

        updateBeam = false;
        firePoint = null;
        
        for(int i = 0; i<particles.Count; i++)
            particles[i].Stop();
    }
    private void FillLists(){
        for (int i = 0; i <startVFX.transform.childCount; i++){
            var ps = startVFX.transform.GetChild(i).GetComponent<ParticleSystem>();
            if(ps != null)
                particles.Add(ps);
        }
        for (int i = 0; i <endVFX.transform.childCount; i++){
            var ps = endVFX.transform.GetChild(i).GetComponent<ParticleSystem>();
            if(ps != null)
                particles.Add(ps);
        }
    }

    private void SetBoxCollider(Vector2 start, Vector2 end){
        float distance = Vector2.Distance(start, end);
        if (Mathf.Abs(dir.x) < Mathf.Abs(dir.y)) box.size = new Vector2(lineRenderer.startWidth, distance);
        else box.size = new Vector2(distance, lineRenderer.startWidth);
        box.offset = (start + end) /2f;
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.enemy)) {
            collision.gameObject.GetComponent<Enemy>()?.Hit(venomBeamDamage);
        }
    }
}
