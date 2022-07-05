using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Rigidbody2D rb;
    Animator anim;

    public Transform groundCheck;
    public LayerMask ground;

    public int jumps = 1;
    public int currentJumps;

    private float moveX;
    private float moveY;
    private Vector2 characterScale;

    bool isTouchingFront;
    public Transform frontCheck;
    bool wallSliding;
    public float wallSlideSpeed;

    bool wallJumping;
    public float xWallForce;
    public float yWallForce;
    public float wallJumpTime = 0.05f;

    public GameObject deadBody;

    public float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    AudioSource audio;

    PitchRandomizer pitch;

    public AudioClip jump;
    public AudioClip doubleJump;
    public AudioClip step;
    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        pitch = GetComponent<PitchRandomizer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentJumps = jumps;
        characterScale = transform.localScale;
    }
    private void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = rb.velocity.y;

        Jump();
        //HandleWallSliding();

        if (isGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
        if (coyoteTimeCounter > 0)
        {
            currentJumps = jumps;
        }

        HandleAnimations();

        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localScale = new Vector2(-characterScale.x, characterScale.y);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localScale = characterScale;
        }
    }

    private void FixedUpdate()
    {
        HandleHorizontalMovement();
    }

    void HandleHorizontalMovement()
    {
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        if (isGrounded() == true)
        {
            rb.velocity = new Vector2(rb.velocity.x * 0.5f, rb.velocity.y);
            currentJumps = jumps;
        }
        if (Input.GetKeyDown(KeyCode.Space) && coyoteTimeCounter > 0f || Input.GetKeyDown(KeyCode.Space) && currentJumps > 0)
        {
            audio.Stop();
            pitch.RandomizeSound();
            if(coyoteTimeCounter > 0f)
            {
                audio.clip = jump;
            }
            else
            {
                audio.clip = doubleJump ;
            }
            audio.Play(0);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            currentJumps--;
        }

        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            coyoteTimeCounter = 0f;
        }
    }

    //  void HandleWallSliding()
    //  {
    //      isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, 0.01f, ground);
    //      if (isTouchingFront == true && isGrounded() == false && moveX != 0)
    //      {
    //          wallSliding = true;
    //      }
    //      else
    //      {
    //          wallSliding = false;
    //      }
    //
    //      if (wallSliding == true)
    //      {
    //          rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, wallSlideSpeed, float.MaxValue));
    //      }
    //
    //      if (Input.GetKeyDown(KeyCode.Space) && wallSliding == true)
    //      {
    //          wallJumping = true;
    //          Invoke("SetWallJumpingToFalse", wallJumpTime);
    //      }
    //
    //      if (wallJumping == true)
    //      {
    //          rb.velocity = new Vector2(xWallForce * -moveX, yWallForce);
    //      }
    //  }

    void SetWallJumpingToFalse()
    {
        wallJumping = false;
    }

    void HandleAnimations()
    {
        anim.SetInteger("Horizontal", (int)moveX);
        anim.SetInteger("Vertical", (int)moveY);
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.01f, ground);
    }

    private bool dying;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Evil"))
        {
            if (!dying)
                Death();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Evil"))
        {
            if (!dying)
                Death();
        }
    }

    public void PlayStepSound()
    {
        if (isGrounded())
        {
            audio.Stop();
            pitch.RandomizeSound();
            audio.clip = step;
            audio.Play(0);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Trigger"))
        {
            if (collision.gameObject.GetComponent<MoveTrigger>())
            {
                collision.gameObject.GetComponent<MoveTrigger>().MoveObject();
            }
            if (collision.gameObject.GetComponent<RotateTrigger>())
            {
                collision.gameObject.GetComponent<RotateTrigger>().RotateObject();
            }
            if (collision.gameObject.GetComponent<InstantiateTrigger>())
            {
                collision.gameObject.GetComponent<InstantiateTrigger>().InstantiationTrigger();
            }
        }
    }

    public void Death()
    {
        dying = true;
        rb.velocity = Vector3.zero;
        GameObject currentRB = Instantiate(deadBody, transform.position, transform.rotation * Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360))));
        currentRB.GetComponent<Rigidbody2D>().AddForce(transform.up * 100);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

