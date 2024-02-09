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
    bool isGrounded;
    private Animator anim;
    private SpriteRenderer sprite;
    float move = 0;
    public GameObject Lamp;

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
        //pêtla odpowiadaj¹ca za skok
       
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rig.velocity = new Vector2(rig.velocity.x, jumpforce);
            
        }

        //mechanizm poruszania right/left
        move = Input.GetAxisRaw("Horizontal");
        rig.velocity = new Vector2(move * speed, rig.velocity.y);

        Running();
    }

    //Funkcja odpowiadaj¹ca za system biegania i odpalaj¹ca odpowiednie animacje
    private void Running()
    {
        if (move > 0f)
        {
            anim.SetBool("isRunning", true);
            sprite.flipX = false;
            Lamp.transform.position = new Vector3(transform.position.x-0.043f, transform.position.y+ 0.243f, 0f);
        }
        if (move < 0f)
        {
            anim.SetBool("isRunning", true);
            sprite.flipX = true;
            Lamp.transform.position = new Vector3(transform.position.x+0.043f, transform.position.y+ 0.243f, 0f);
        }
        if (move == 0f)
        {
            anim.SetBool("isRunning", false);
        }
    }

    


}

