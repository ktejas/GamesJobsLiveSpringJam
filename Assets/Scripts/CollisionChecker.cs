using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    GameObject gameManager = default;
    DragController dragController;

    public Material crackedMaterial;
    private Material currentMaterial;
    private bool bDestroy = false;

    public string blockName = "green";

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
        dragController = GetComponent<DragController>();
        currentMaterial = GetComponentInChildren<MeshRenderer>().material;
    }
    void OnCollisionEnter(Collision otherCollision)
    {
        //Debug.Log("Collided.");
        //if (otherCollision.gameObject.tag == "Block" && dragController.state == DragController.State.dropped)
        //{
        //    //if(MaterialPropertyBlock color is same)
        //    Debug.Log("Similar blocks are colliding.");

        //    // Telling the GameManager, so the strength calculation can be changed
        //    gameManager.GetComponent<GameManager>().increaseCollisionCount(1);
        //}
        if (otherCollision.gameObject.tag != "IgnoreCollision")
        {
            //print("hitfloor");
            gameManager.GetComponent<GameManager>().UpdateY(transform.position.y);
        }
    }

    void OnTriggerEnter(Collider otherCollider)
    {
        //Debug.Log("Trigger.");
        if (otherCollider.gameObject.tag == "Block" && dragController.state == DragController.State.dropped && blockName == otherCollider.GetComponent<CollisionChecker>().blockName)
        {
            //if(MaterialPropertyBlock color is same)
            Debug.Log("Similar blocks are colliding.");
            bDestroy = false;
            otherCollider.gameObject.GetComponent<CollisionChecker>().bDestroy = true;
            otherCollider.gameObject.GetComponentInChildren<MeshRenderer>().material = crackedMaterial;
            GetComponentInChildren<MeshRenderer>().material = currentMaterial;
            bDestroy = false;
            
            StartCoroutine(DestroyBlock());

            // Telling the GameManager, so the strength calculation can be changed
            gameManager.GetComponent<GameManager>().increaseCollisionCount(1);
        }
        if (otherCollider.gameObject.tag != "IgnoreCollision")
        {
            //print("hitfloor");
            gameManager.GetComponent<GameManager>().UpdateY(transform.position.y);
        }
    }

    IEnumerator DestroyBlock()
    {
        yield return new WaitForSeconds(3.0f);
        if(bDestroy) Destroy(gameObject);
    }
}
