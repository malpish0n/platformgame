using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Rigidbody2D rig;
    public float speed = 20f;

    public float jumpforce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.2f;

    public float landingCheckRadius = 0.3f;
    bool isGrounded;
    bool isLanding;
    public Transform landingCheck;
    private Animator anim;

    private SpriteRenderer sprite;
    float move = 0;
    public GameObject Lamp;

    bool jump = false;
    bool landing = false;
    float time = 0.433f;
    float jumpTime;
    public float jumpStartTime;
    bool offtheGround;

    bool isWallSliding;
    public float wallSlidingSpeed;
    public GameObject wallDetect;
    public float wallDetectRadius;
    public LayerMask wallLayer;

    public bool isWallJumping;
    float wallJumpDirection;
    bool wallJumpDirBol;
    public float wallJumpTime;
    public Vector2 wallJumpVelocity;
    float wallJumpCounter;
    public float wallJumpDuration;
    float wallJumpDurationPass;







    // Start is called before the first frame update
    void Start()
    {
        //pobieranie kompomentów i dopasowywanie ich do zmiennych
        rig = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //zmienna isGrounded sprawdzaj¹ca czy gracz dotyka pod³ogi 
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        //zmienna isLanding sprawdzajaca czy gracz zbliza sie do l¹dowania
        isLanding = Physics2D.OverlapCircle(landingCheck.position, landingCheckRadius, groundLayer);

        if (!isWallJumping)
        {
            Running();
        }

        //mechanizm poruszania right/left
        move = Input.GetAxisRaw("Horizontal");

        Jump();
        WallSliding();
        WallJumping(); //lekki bug gdy bardzo szybko klikniesz np. na lewej œcianie d najpierw i spacjê to mo¿e skoczyæ w z³¹ stronê. Jak naprawiæ (nie wiem)

    }
    private void FixedUpdate()
    {
        if (!isWallJumping)
        {
            rig.velocity = new Vector2(move * speed, rig.velocity.y);
        }

    }

    //Funkcja odpowiadaj¹ca za system biegania i odpalaj¹ca odpowiednie animacje
    private void Running()
    {
        if (move > 0f)
        {
            anim.SetBool("isRunning", true);
            sprite.flipX = false;
            Lamp.transform.position = new Vector3(transform.position.x-0.14f, transform.position.y+ 0.766f, 0f);
        }
        if (move < 0f)
        {
            anim.SetBool("isRunning", true);
            sprite.flipX = true;
            Lamp.transform.position = new Vector3(transform.position.x+ 0.14f, transform.position.y+ 0.766f, 0f);
        }
        if (move == 0f)
        {
            anim.SetBool("isRunning", false);
        }
    }

    //Funkcja odpowiadaj¹ca za system skoko wraz z jego animacj¹
    private void Jump()
    {
        if (isGrounded)
        {
            anim.SetBool("Landing", false);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            anim.SetBool("Jump", true);
            jump = true;
            jumpTime = jumpStartTime;
            rig.velocity = new Vector2(rig.velocity.x, jumpforce);
            offtheGround = true;
        }

        if(jump && Input.GetButton("Jump"))
        {
            if(jumpTime > 0)
            {
                rig.velocity = new Vector2(rig.velocity.x, jumpforce);
                jumpTime -= Time.deltaTime;
            }
            else
            {
                jump = false;
            }
        }
        if (Input.GetButtonUp("Jump"))
        {
            jump = false;
        }

        if (offtheGround)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                anim.SetBool("Jump", false);
                offtheGround = false;
                time = 0.433f;
                landing = true;
            }
        }

        if (isLanding && landing)
        {
            anim.SetBool("Landing", true);
            landing = false;
        }
    }
    bool isWall()
    {
        return Physics2D.OverlapCircle(wallDetect.transform.position, wallDetectRadius, wallLayer);
    }
    

    void WallSliding()
    {
        if(isWall() && !isGrounded && move!= 0)
        {
            isWallSliding = true;
            rig.velocity = new Vector2(rig.velocity.x, Mathf.Clamp(rig.velocity.y, -wallSlidingSpeed, float.MaxValue));

        }
        
        else
        {
            isWallSliding = false;
        }
    }

    void WallJumping() //lekki bug gdy bardzo szybko klikniesz np. na lewej œcianie d najpierw i spacjê to mo¿e skoczyæ w z³¹ stronê. Jak naprawiæ (nie wiem)
    {
        if (isWallSliding)
        {
            wallJumpDirBol = !sprite.flipX;
            wallJumpCounter = wallJumpTime;
            if (wallJumpDirBol)
            {
                wallJumpDirection = -1;
            }
            else
            {
                wallJumpDirection = 1;
            }
        }
        else
        {
            wallJumpCounter -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Jump") && wallJumpCounter > 0)
        {
            isWallJumping = true;
            rig.velocity = new Vector2(wallJumpDirection*wallJumpVelocity.x, wallJumpVelocity.y);
            wallJumpCounter = 0;
            if (sprite.flipX != wallJumpDirBol)
            {
                sprite.flipX = !sprite.flipX;
            }
            wallJumpDurationPass = wallJumpDuration;


        }
        if (isWallJumping)
        {
            wallJumpDurationPass -= Time.deltaTime;
            if(wallJumpDurationPass < 0)
            {
                StopWallJumping();
            }
        }

    }

    void StopWallJumping()
    {
        isWallJumping = false;
    }
}

