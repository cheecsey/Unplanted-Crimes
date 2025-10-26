using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D PlayaBody;
    public SpriteRenderer PlayaSprite;
    public BoxCollider2D PlayaHitBox;
    public float leftSpeed = 100;
    public float rightSpeed = 100;
    public float JumpSpeed = 100;
    public Text money;
    bool colliding = false;
    GameObject bushel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A) == true || Input.GetKeyDown(KeyCode.LeftArrow) == true)
        {
            PlayaBody.linearVelocity = Vector2.left * leftSpeed;
            FlipPlaya();
        }
        else if (Input.GetKeyDown(KeyCode.D) == true || Input.GetKeyDown(KeyCode.RightArrow) == true)
        {
            PlayaBody.linearVelocity = Vector2.right * rightSpeed;
            FlipPlaya();
        }
        else if (Input.GetKeyDown(KeyCode.E) == true && colliding == true)
        {
            Destroy(bushel);
        }
        else if (Input.GetKeyDown(KeyCode.Space) == true || Input.GetKeyDown(KeyCode.UpArrow) == true)
        {
            PlayaBody.linearVelocity = Vector2.up * JumpSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        colliding = true;
        bushel = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        colliding=false;
    }

    void FlipPlaya()
    {
        PlayaSprite.flipX = true;
    }
}
