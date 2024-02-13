using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float cameraFollowSpeed;
    public float minCameraFromGround;
    Vector3 newpos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.y > minCameraFromGround || transform.position.y> minCameraFromGround)
        {
            newpos = new Vector3(player.position.x, player.position.y, -10f);
        }
        else
        {
            newpos = new Vector3(player.position.x, transform.position.y, -10f);
        }
        transform.position = Vector3.Slerp(transform.position, newpos, cameraFollowSpeed * Time.deltaTime);

    }
}
