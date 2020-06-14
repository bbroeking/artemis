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
    public HealthBar healthbar;
    public GameObject crosshair;
    public GameObject inventory;

    private void Start()
    {
        //Cursor.visible = false;
    }
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Magnitude", movement.magnitude);

        Move(movement);
        Aim();

        if (Input.GetKeyDown("i") == true)
        {
            inventory.SetActive(!inventory.activeSelf);
        }
    }

    void Move(Vector3 movement)
    {
        rb.velocity = new Vector2(movement.x * 3, movement.y * 3);
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
        // Vector2 lookDir = worldPosition - rb.position;
        // float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        // rb.rotation = angle;
    }
}
