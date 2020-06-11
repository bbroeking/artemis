using System.Numerics;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    private float enemyForce = 200f;
    public HealthBar healthbar;
    public GameObject crosshair;

    private void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Magnitude", movement.magnitude);

        Move(movement);
        Aim();
    }

    void Move(Vector3 movement)
    {
        rb.velocity = new Vector2(movement.x * 6, movement.y * 6);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            HandleHealth();
            Rigidbody2D enemyRb = collision.gameObject.GetComponent<Rigidbody2D>();
            enemyRb.velocity = new Vector2(10f, 10f);
            rb.velocity = new Vector2(-enemyForce, -enemyForce);
        }
    }

    private void HandleHealth()
    {
        PermanentUI.perm.health -= 1;
        healthbar.SetHealth(PermanentUI.perm.health);
        if (PermanentUI.perm.health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void Aim()
    {
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        crosshair.transform.localPosition = worldPosition;

        // Look that way 
        Vector2 lookDir = worldPosition - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
