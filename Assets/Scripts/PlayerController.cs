using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveForce = 10f;
    [SerializeField] private float _jumpForce;
    public float moveX;

    [SerializeField] private float gravityScale = 5;
    [SerializeField] private float fallGravityScale = 15f;
    [SerializeField] private float jumpHeight = 5;
    private bool Jumped { get; set; }

    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator anim;

    private string walkAnimation = "walk";
    private string jumpAnimation = "Jump";
    private string Ground_Tag = "Ground";
    private string Enemy = "Enemy";

    public CoinManager coinManager;
    private PowerupManager powerup;

    private bool isOnGround = true;
    private PlayerControls inputs;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        powerup = GetComponent<PowerupManager>();
        inputs = new PlayerControls();

        if (coinManager == null)
        {
            coinManager = GameObject.FindGameObjectWithTag("ExpendablesManager").GetComponent<CoinManager>();
            if (coinManager == null)
            {
                GameObject expendablesManager = new GameObject("ExpendablesManager");
                coinManager = expendablesManager.AddComponent<CoinManager>();
                powerup = expendablesManager.AddComponent<PowerupManager>();
            }
        }
    }

    void Start()
    {
        inputs.Player.Enable();
        inputs.Player.Jump.performed += (context) => Jumped = context.ReadValueAsButton();
    }

    void Update()
    {
        PlayerMoveKeyboard();
        PlayerAnimation();
        ApplyGravity();
    }

    private void FixedUpdate()
    {
        Jump_performed();
    }



    void PlayerMoveKeyboard()
    {
        moveX = inputs.Player.Move.ReadValue<Vector2>().x;
        Vector2 moveVector = new Vector2(moveX * moveForce, rb.velocity.y);
        rb.velocity = moveVector;
    }

    void PlayerAnimation()
    {
        if (moveX > 0)
        {
            anim.SetBool(walkAnimation, true);
            sr.flipX = false;
        }
        else if (moveX < 0)
        {
            anim.SetBool(walkAnimation, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(walkAnimation, false);
        }
    }

    void ApplyGravity()
    {
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallGravityScale;
        }
    }

    private void Jump_performed()
    {
        if (isOnGround && Jumped)
        {
            _jumpForce = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * rb.gravityScale) * -2) * rb.mass;
            rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            rb.gravityScale = gravityScale;
            anim.SetBool(jumpAnimation, true);
            isOnGround = false;
            Jumped = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Ground_Tag))
        {
            anim.SetBool(jumpAnimation, false);
            isOnGround = true;
        }
        if (collision.gameObject.CompareTag(Enemy))
        {
            if (!powerup.isIndestructible())
            {
                Destroy(gameObject);
            }
            else
            {
                Destroy(collision.gameObject);
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Enemy) && !powerup.isIndestructible())
        {
            Destroy(gameObject);
        }
        else if (collision.CompareTag(Enemy))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coinManager.coinCount++;
        }
    }

    private void OnDisable()
    {
        inputs.Player.Disable();
    }
}
