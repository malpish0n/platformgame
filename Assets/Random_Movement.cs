using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;

public class Random_Movement : MonoBehaviour
{
    float positionx;
    float positiony;
    public float maxDistance;
    Vector2 waypoint;
    public float speed;
    public float range;
    // Start is called before the first frame update
    void Start()
    {
        positionx = transform.position.x;
        positiony = transform.position.y;
        waypoint = new Vector2(Random.Range(-maxDistance, maxDistance) + positionx, Random.Range(-maxDistance, maxDistance) + positiony);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoint, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position,waypoint) < range)
        {
            SetNewDestination();
        }
        
    }

    void SetNewDestination()
    {
        waypoint = new Vector2(Random.Range(-maxDistance, maxDistance)+positionx, Random.Range(-maxDistance, maxDistance)+positiony);
    }
}
