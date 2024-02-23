using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class Doors : MonoBehaviour
{
    public bool toKitchen;
    public bool toBedroom;
    public bool toBasement;
    public bool toKitchenDestroyed;
    public GameObject BedRoom;
    public GameObject Corridor;
    public GameObject Basement;
    public GameObject Button;
    public GameObject DoorstoKitchenDestroyed;
    public GameObject CorridorDestroyed;
    public Movement player;
    bool onTrig;
    bool Fade;
    public bool Fadeout;
    public Image background;
    float Timepass;
    public float time;
    Color Color;
    float f = 0f;
    bool CanClick;

    // Start is called before the first frame update
    void Start()
    {
        Timepass = time;
        CanClick = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (onTrig)
        {
            if (CanClick)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    player.CanMove = false;
                    Fade = true;
                    f = 0f;
                    CanClick = false;
                }
            }
            if(Fade)
            {
                if (Timepass < 0 && f < 1)
                {
                    f += 0.01f;
                    Color.a = f;
                    background.color = Color;
                    Timepass = time;
                }
                Timepass -= Time.deltaTime;
                if (f >= 1)
                {
                    Fadeout = true;
                    Fade = false;
                    player.CanMove = true;
                    CanClick = true;
                    if (toKitchen)
                    {
                        DoorstoKitchenDestroyed.SetActive(true);
                        BedRoom.SetActive(false);
                        Corridor.SetActive(true);
                        gameObject.SetActive(false);
                    }
                    if (toKitchenDestroyed)
                    {
                        BedRoom.SetActive(false);
                        CorridorDestroyed.SetActive(true);
                    }
                    if (toBedroom)
                    {
                        CorridorDestroyed.SetActive(false);
                        BedRoom.SetActive(true);
                    }
                    if (toBasement)
                    {
                        Corridor.SetActive(false);
                        Basement.SetActive(true);
                    }
                }
                
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "mainCharacter")
        {
            Button.SetActive(true);
            onTrig = true;
            
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "mainCharacter")
        {
            onTrig = false;
            Button.SetActive(false);
        }
    }
}
