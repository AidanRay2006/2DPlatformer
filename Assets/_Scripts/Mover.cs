using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Transform PointA;
    public Transform PointB;
    public bool Moving = false;
    public float MinDistance = 0.01f;
    public float speed = 1.2f;

    private bool MovingToPointA = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //nothing happens if not moving
        if (!Moving)
        {
            return;
        }

        CheckDirection();

        if (MovingToPointA)
        {
            transform.position = Vector2.MoveTowards(transform.position, PointA.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, PointB.position, speed * Time.deltaTime);
        }

    }

    private void CheckDirection()
    {
        //make sure that it is moving to point a or not
        if (MovingToPointA)
        {
            if (Vector2.Distance(transform.position, PointA.position) <= MinDistance)
            {
                MovingToPointA = false;
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, PointB.position) <= MinDistance)
            {
                MovingToPointA = true;
            }
        }
    }
}
