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





    // Start is called before the first frame update
    void Start()
    {
        //pobieranie kompoment�w i dopasowywanie ich do zmiennych
        rig = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //zmienna isGrounded sprawdzaj�ca czy gracz dotyka pod�ogi 
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        //zmienna isLanding sprawdzajaca czy gracz zbliza sie do l�dowania
        isLanding = Physics2D.OverlapCircle(landingCheck.position, landingCheckRadius, groundLayer);

        Running();

        //mechanizm poruszania right/left
        move = Input.GetAxisRaw("Horizontal");
        rig.velocity = new Vector2(move * speed, rig.velocity.y);

        Jump();

    }
    private void FixedUpdate()
    {

        rig.velocity = new Vector2(move * speed, rig.velocity.y);

    }

    //Funkcja odpowiadaj�ca za system biegania i odpalaj�ca odpowiednie animacje
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

    //Funkcja odpowiadaj�ca za system skoko wraz z jego animacj�
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
}

