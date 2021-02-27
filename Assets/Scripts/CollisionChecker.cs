using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    GameObject gameManager = default;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
    }
    void OnCollisionEnter(Collision otherCollision)
    {
        if(otherCollision.gameObject.tag == "Block")
        {
            //if(MaterialPropertyBlock color is same)
            Debug.Log("Similar blocks are colliding.");

            // Telling the GameManager, so the strength calculation can be changed
            gameManager.GetComponent<GameManager>().increaseCollisionCount(1);
        }
        if (otherCollision.gameObject.tag != "IgnoreCollision"){
            print("hitfloor");
            gameManager.GetComponent<GameManager>().UpdateY(transform.position.y);
        }
    }
}
