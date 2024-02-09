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
    bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        //pêtla odpowiadaj¹ca za skok
       
        if (true){
            Debug.Log(isGrounded);
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rig.velocity = new Vector2(rig.velocity.x, jumpforce);
        }

        //mechanizm poruszania right/left
        float move = Input.GetAxisRaw("Horizontal");
        rig.velocity = new Vector2(move * speed, rig.velocity.y);

        if (move > 0)
        {
            if (!facingRight) { 
                transform.Rotate(0, 180, 0);
                facingRight = true;
            }
        }
        if (move < 0)
        {
            if (facingRight)
            {
                transform.Rotate(0, -180, 0);
                facingRight = false;
            }
        }
    }

    


}

