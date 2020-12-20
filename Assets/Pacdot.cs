using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacdot : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        // TO DO: Increase highscore here
        if (collision.name == "pacman")
            
            Destroy(gameObject);
    }

}
