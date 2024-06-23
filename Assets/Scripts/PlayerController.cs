using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveForce =10f;
    public float jumpForce = 11f;
    public float moveX;

    public SpriteRenderer sr;
    public Rigidbody2D rd;
    public Animator anim;

    private string walkAnimation = "walk";
    private string jump = "Jump";
    private string Ground_Tag = "Ground";
    private string Enemy = "Enemy";


    private bool isOnGround = true;
    // Start is called before the first frame update

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        PlayerAnimation();
    }

    private void FixedUpdate()
    {
        PlayerJump();
    }

    void PlayerMoveKeyboard()
    {
        moveX = Input.GetAxisRaw("Horizontal");

        Vector2 pos = transform.position;
        pos.x += moveX * moveForce * Time.deltaTime;
        transform.position = pos;

    }

    void PlayerAnimation()
    {
       
        if (moveX > 0)
        {
            anim.SetBool(walkAnimation, true);
            sr.flipX = false;
        }
        else if(moveX < 0) {
            anim.SetBool(walkAnimation, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(walkAnimation, false);
            
        }
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown(jump) && isOnGround)
        {
            rd.AddForce(new Vector2(0f, jumpForce) , ForceMode2D.Impulse);
            isOnGround = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Ground_Tag))
        {
            isOnGround = true;
        }

        if (collision.gameObject.CompareTag(Enemy))
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Enemy))
        {
            Destroy(gameObject);
        }
    }
}
