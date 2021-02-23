using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    private void OnCollisionEnter(Collision otherCollision)
    {
        if(otherCollision.gameObject.tag == "Block")
        {
            //if(MaterialPropertyBlock color is same)
            Debug.Log("Similar blocks are colliding.");
        }
    }
}
