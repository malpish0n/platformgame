using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class IntoKitchen : MonoBehaviour
{
    public Doors toKitchenscript;
    public Doors toBedroomscript;
    public Doors toBasementscript;
    public GameObject DoorsToKitchen;
    public GameObject DoorsToBedroom;
    public GameObject DoorsToBasement;
    public GameObject DoorsToKitchenfromBasement;
    float Timepass;
    public float time;
    Color Color;
    float f = 1f;
    public Image background;
    public CameraFollow follow;




    // Start is called before the first frame update
    void Start()
    {
        Timepass = time;
    }

    // Update is called once per frame
    void Update()
    {
        if (toKitchenscript.toKitchen == true)
        {
            if (toKitchenscript.Fadeout == true)
            {
                
                DoorsToBedroom.SetActive(false);
                follow.maxCameraleft = -6.14f;
                if (Timepass < 0 && f > 0)
                {
                    f -= 0.01f;
                    Color.a = f;
                    background.color = Color;
                    Timepass = time;
                }
                Timepass -= Time.deltaTime;
                if (f <= 0)
                {
                    toKitchenscript.Fadeout = false;
                    f = 1f;
                    DoorsToBedroom.SetActive(true);
                }

            }
        }
        if (toBedroomscript.toBedroom == true)
        {
            if (toBedroomscript.Fadeout == true)
            {
                DoorsToKitchen.SetActive(false);
                follow.maxCameraleft = -4.64f;
                if (Timepass < 0 && f > 0)
                {
                    f -= 0.01f;
                    Color.a = f;
                    background.color = Color;
                    Timepass = time;
                }
                Timepass -= Time.deltaTime;
                if (f <= 0)
                {
                    toBedroomscript.Fadeout = false;
                    f = 1f;
                    DoorsToKitchen.SetActive(true);
                }

            }
        }
        if (toBasementscript.toBasement == true)
        {
            if (toBasementscript.Fadeout == true)
            {

                DoorsToKitchenfromBasement.SetActive(false);
                follow.maxCameraleft = /*uzupelnic */0;
                if (Timepass < 0 && f > 0)
                {
                    f -= 0.01f;
                    Color.a = f;
                    background.color = Color;
                    Timepass = time;
                }
                Timepass -= Time.deltaTime;
                if (f <= 0)
                {
                    toBasementscript.Fadeout = false;
                    f = 1f;
                    DoorsToKitchenfromBasement.SetActive(true);
                }

            }
        }
    }
}
