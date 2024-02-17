using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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
        }
    }
}
