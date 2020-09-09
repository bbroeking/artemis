using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenomBeam : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] BoxCollider2D box;
    private Transform firePoint;
    private Vector3 dir;
    private bool updateBeam;

    public GameObject startVFX;
    public GameObject endVFX;
    private List<ParticleSystem> particles = new List<ParticleSystem>();

    private int venomBeamDamage= 1;
    
    void Start()
    {
        FillLists();
        DisableBeam();
    }

    void Update()
    {
        if (updateBeam) UpdateBeam();
    }

    public void EnableBeam(Transform firePoint, Vector3 dir){
        // Enable Objects 
        lineRenderer.enabled = true;
        box.enabled = true;

        this.firePoint = firePoint;
        this.dir = dir;

        updateBeam = true;

        for(int i = 0; i<particles.Count; i++)
            particles[i].Play();
    }

    private void UpdateBeam(){
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
        
        this.dir = Vector3.zero;

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
        if (dir.x < dir.y) box.size = new Vector2(lineRenderer.startWidth*2, distance);
        else box.size = new Vector2(distance, lineRenderer.startWidth*2);
        box.offset = start;
    }
    
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.enemy)) {
            collision.gameObject.GetComponent<Enemy>()?.Hit(venomBeamDamage);
        }
    }
}
