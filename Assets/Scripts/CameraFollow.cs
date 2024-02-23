using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float cameraFollowSpeed;
    public float minCameraFromGround;
    public float maxCameraleft;
    public float maxCameraright;
    Vector3 newpos;
    // Start is called before the first frame update
    void Start()
    {
        newpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (player.position.y > minCameraFromGround || transform.position.y > minCameraFromGround)
        //{
        //    newpos = new Vector3(player.position.x, player.position.y, -10f);
        // }
        //else
        //{
        //    newpos = new Vector3(player.position.x, transform.position.y, -10f);
        //}
        if(transform.position.x < maxCameraleft)
        {
            transform.position = new Vector3(maxCameraleft, transform.position.y, -10f);
            newpos = transform.position;
        }
        if (transform.position.x > maxCameraright)
        {
            transform.position = new Vector3(maxCameraright, transform.position.y, -10f);
            newpos = transform.position;
        }
        else
        {
            if (player.position.x > maxCameraleft && player.position.x < maxCameraright)
            {
                newpos = new Vector3(player.position.x, transform.position.y, -10f);
            }
            transform.position = Vector3.Slerp(transform.position, newpos, cameraFollowSpeed * Time.deltaTime);
        }
            

    }
    public void Transport()
    {
        transform.position = new Vector3(player.position.x, transform.position.y,-10f);
        newpos = transform.position;
    }
}
