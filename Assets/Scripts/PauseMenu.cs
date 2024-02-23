using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Pause_Menu;
    public Image background;
    public GameObject Buttons;
    bool isPaused;
    Color Color;
    public float time = 0.05f;
    float Timepass;
    float f;
    bool isActivating;
    bool isDeactivating;
    bool Exiting;
    
    // Start is called before the first frame update
    void Start()
    {
        Color = background.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Exiting)
        {
            if (Input.GetButtonDown("Pause") && !isPaused && !isActivating)
            {
                Pause_Menu.SetActive(true);
                isActivating = true;
                isDeactivating = false;
            }

            if (isActivating)
            {
                if (Timepass < 0 && f < 0.8)
                {
                    f += 0.05f;
                    Color.a = f;
                    background.color = Color;
                    Timepass = time;
                }
                Timepass -= Time.deltaTime;
                if (f >= 0.8)
                {
                    isPaused = true;
                    Time.timeScale = 0;
                    Buttons.SetActive(true);
                }
            }




            if (Input.GetButtonDown("Pause") && isPaused && !isDeactivating)
            {
                isActivating = false;
                isDeactivating = true;
                Time.timeScale = 1;
                Buttons.SetActive(false);
            }

            if (isDeactivating)
            {
                if (Timepass < 0 && f > 0)
                {
                    f -= 0.05f;
                    Color.a = f;
                    background.color = Color;
                    Timepass = time;
                }
                Timepass -= Time.deltaTime;
                if (f <= 0)
                {
                    isPaused = false;
                    Pause_Menu.SetActive(false);
                }
            }
        }
        else
        {
            if (Timepass < 0 && f <1)
            {
                f += 0.01f;
                Color.a = f;
                background.color = Color;
                Timepass = time;
            }
            Timepass -= Time.deltaTime;
            if (f >= 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }

        
    }

    public void Resume()
    {
        isActivating = false;
        isDeactivating = true;
        Time.timeScale = 1;
        Buttons.SetActive(false);
    }

    public void Exit()
    {
        Exiting = true;
        Time.timeScale = 1;
        Buttons.SetActive(false);
    }
}
