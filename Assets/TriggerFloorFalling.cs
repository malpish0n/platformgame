using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFloorFalling : MonoBehaviour
{
    public FloorFalling script;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "mainCharacter")
        {
            script.startEvent = true;
            gameObject.SetActive(false);
        }
    }
}
