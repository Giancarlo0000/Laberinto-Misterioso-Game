using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDMovement : MonoBehaviour
{
    public float regularSpeed = 5f;
    public float maxSpeed = 10f;
    public float minimumSpeed = 2f;
    private SpriteRenderer spriteRenderer;
    
    [HideInInspector] public float currentSpeed = 5f;

    public float regularCamera = 2.5f;
    public float maxCamera = 5f;
    [HideInInspector] public float currentCamera = 2.5f;

    public GameObject camara;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float dirX = Input.GetAxis("Horizontal");
        float dirY = Input.GetAxis("Vertical");
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(dirX * currentSpeed, dirY * currentSpeed);
        if (dirX > 0)
        {
            spriteRenderer.flipX = false;
        }
        if (dirX < 0)
        {
            spriteRenderer.flipX = true;
        }
        camara.GetComponent<Camera>().orthographicSize = currentCamera;
    }
 
    public void ChangeSpeedToFast()
    {
        currentSpeed = maxSpeed;
        Invoke("ResetSpeed", 2);
    }

    public void ChangeSpeedToSlow()
    {
        currentSpeed = minimumSpeed;
        Invoke("ResetSpeed", 4);
    }

    void ResetSpeed()
    {
        currentSpeed = regularSpeed;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;

    }

    public void ChangeCameraSize()
    {
        currentCamera = maxCamera;
        Invoke("ResetCamera", 4);
    }

    void ResetCamera()
    {
        currentCamera = regularCamera;
    }

    public void ChangeCollision()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f, 1f,0.5f);
        Invoke("ResetCollision", 7);
    }
    void ResetCollision()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }
}
