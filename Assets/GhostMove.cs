using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour
{
    public Transform[] waypoints;
    int cur = 0;

    public float speed = 0.3f;

    void FixedUpdate()
    {
        // Waypoint not reached yet? then move closer
        Debug.Log("Destination Not Reached!");
        if (transform.position != waypoints[cur].position)
        {
            // Calculate a position that is a bit closer to the waypoint
            Vector2 p = Vector2.MoveTowards(transform.position,
                                            waypoints[cur].position,
                                            speed);
            // Set ghosts position
            GetComponent<Rigidbody2D>().MovePosition(p);
            Debug.Log("Moving Toward Destination.");
        }
        // Waypoint reached, select next one
        // NOT WORKING!!!!
        else
        {
            Debug.Log("Destination Reached. Cur is " +cur);
            Debug.Log("Looking for Next Destination...");
            //cur = (cur + 1) % waypoints.Length;
            cur += 1;
            if (cur == waypoints.Length)
            {
                cur = 0;
            }
        }

        //Animation
        Vector2 dir = waypoints[cur].position - transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "pacman")
        {
            Destroy(gameObject);
            // Decease lives, then either respawn or gameover screen
        }
    }
}
