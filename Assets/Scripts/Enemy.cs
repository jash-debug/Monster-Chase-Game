using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Rigidbody2D myBody;
    public float speed = 5f;

    public float destroyBoundary = 25.0f;
    

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -destroyBoundary || transform.position.x >= destroyBoundary)
        {
            Destroy(gameObject); // Destroy the enemy object
        }
    }

    private void FixedUpdate()
    {
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
    }
}
