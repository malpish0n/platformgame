using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class Doors : MonoBehaviour
{
    public GameObject BedRoom;
    public GameObject Corridor;
    public GameObject Button;
    bool onTrig;
    bool Fade;
    bool Fadeout;
    public Image background;
    float Timepass;
    public float time;
    Color Color;
    float f = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Timepass = time;
    }

    // Update is called once per frame
    void Update()
    {
        if (onTrig)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Fade = true;
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
                    BedRoom.SetActive(false);
                    Corridor.SetActive(true);
                }
                
            }
            if (Fadeout)
            {
                if (Timepass < 0 && f > 0)
                {
                    f -= 0.01f;
                    Color.a = f;
                    background.color = Color;
                    Timepass = time;
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
