using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FloorFalling : MonoBehaviour
{
    public bool startEvent;
    public cameraShake cameraShake;
    public float duration;
    public float magnitude;
    public Animator anim;
    float animtime= 0.717f;
    bool continueevent;
    public GameObject root;
    public GameObject blackScreen;
    public float blackTime;
    public Animator blackanim;
    public GameObject Old_Kitchen;
    public GameObject New_Kitchen;
    public CameraFollow cameraf;
    public Movement player;

    private void Update()
    {
        if (startEvent)
        {
            StartCoroutine(cameraShake.Shake(duration, magnitude));
            continueevent = true;
            player.CanMove = false;
            startEvent = false;
        }
        if (continueevent)
        {
            duration -= Time.deltaTime;
            if(duration <= animtime)
            {
                anim.SetBool("Attack", true);
                
            }
            if(duration < 0)
            {
                root.SetActive(false);
                blackScreen.SetActive(true);
                Old_Kitchen.SetActive(false);
                New_Kitchen.SetActive(true);
                blackTime -= Time.deltaTime;
            }
            if(blackTime < 0)
            {
                blackanim.SetBool("Out", true);
                cameraf.maxCameraright = -2.77f;
                
            }
            if(blackTime < -2f)
            {
                continueevent = false;
                player.CanMove = true;
                blackScreen.SetActive(false);
            }
        }
    }
}
