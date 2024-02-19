using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Random_Light : MonoBehaviour
{
    Light2D light_close;
    Light2D light_long;
    public GameObject light_close_gameObject;
    public float time_beetwen_changes = 2f;
    float number = 0;
    float previous_number =0;
    float intensity;
    // Start is called before the first frame update
    void Start()
    {
        light_long = GetComponent<Light2D>();
        light_close = light_close_gameObject.GetComponent<Light2D>();
        number = UnityEngine.Random.Range(0, 5);


    }

    // Update is called once per frame
    void Update()
    {
        time_beetwen_changes -= Time.deltaTime;
        if(time_beetwen_changes < 0)
        {
            
            if (number > previous_number)
            {
                intensity += 0.01f;
                light_close.intensity = intensity*20;
                light_long.intensity = (float)(intensity * 0.1);
                if (intensity > number)
                {
                    time_beetwen_changes = 2f;
                    previous_number = number;
                    number = UnityEngine.Random.Range(0, 5);
                }
            }
            else
            {
                intensity -= 0.01f;
                light_close.intensity = intensity * 20;
                light_long.intensity = (float)(intensity * 0.1);
                if (intensity < number)
                {
                    time_beetwen_changes = 2f;
                    previous_number = number;
                    number = UnityEngine.Random.Range(0, 5);

                }
            }
        }
        
        
        

    }
}
