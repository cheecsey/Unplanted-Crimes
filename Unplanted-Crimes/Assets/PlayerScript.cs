using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D PlayaBody;
    public Text SeedMoneyCount;
    public float leftSpeed = 100;
    public float rightSpeed = 100;
    public float JumpSpeed = 100;
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
        }
        else if (Input.GetKeyDown(KeyCode.D) == true || Input.GetKeyDown(KeyCode.RightArrow) == true)
        {
            PlayaBody.linearVelocity = Vector2.right * rightSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.E) == true)
        {
            SeedMoneyCount.text = SeedMoneyCount.text + 10;
            Debug.Log(SeedMoneyCount.text);
        }
        else if (Input.GetKeyDown(KeyCode.Space) == true || Input.GetKeyDown(KeyCode.UpArrow) == true)
        {
            PlayaBody.linearVelocity = Vector2.up * JumpSpeed;
        }
    }
}
