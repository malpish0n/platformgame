using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public Transform player;
    public float follow_distance;
    public float attack_distance;
    public float move_speed;
    bool isFollowing = false;
    Animator anim;
    float time = 1.35f;
    public float PatrolRange;
    Vector2 startPosition;
    Rigidbody2D rig;
    public float patrol_speed;
    float direction = -1;
    SpriteRenderer sprite;
    bool flip;
   

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing)
        {
            if (Vector2.Distance(transform.position, player.position) > attack_distance)
            {
                if (transform.position.x < player.position.x)
                {
                    transform.position += Vector3.right * move_speed * Time.deltaTime;
                }
                if(transform.position.x > player.position.x)
                {
                    transform.position += Vector3.left * move_speed * Time.deltaTime;
                }
            }
            else
            {
                anim.SetBool("Attack", true);
                time -= Time.deltaTime;
                if(time < 0)
                {
                    Destroy(gameObject);
                }

            }

        }
        else
        {
            if (Vector2.Distance(transform.position, player.position) < follow_distance)
            {
                isFollowing = true;
            }
            else
            {
                isFollowing = false;
                if (Vector2.Distance(startPosition, transform.position) < PatrolRange)
                {
                    rig.velocity = new Vector2(patrol_speed * direction, rig.velocity.y);
                    flip = true;
                }
                else
                {
                    if (flip)
                    {
                        direction = -direction;
                        sprite.flipX = !sprite.flipX;
                        rig.velocity = new Vector2(patrol_speed * direction, rig.velocity.y);
                        flip = false;
                    }
                    
                }
            }
        }
    }
    
}
