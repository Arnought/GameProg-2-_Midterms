using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpd;

    // Reference to the MeshRenderer component attached to this object.
    public MeshRenderer rend;

    private Transform target;

    // To the GameObject that will be instantiated for removal object.
    public GameObject remove;


    // Public property to access the Material of the MeshRenderer.
    public Material mat 
    { 
        get 
        { 
            return rend.material; 
        } 
    
    }

    void Start()
    {
        // Find and set the player's transform as the target for this object to look at.
        target = GameObject.FindGameObjectWithTag("Player").transform;
        transform.LookAt(target);

        // Set the material color of this object to a random color obtained from the GameManager.
        rend.material.color = GameManager.Instance.RandomColor();
    }

    void FixedUpdate()
    {
        // Move the enemy forward based on its forward direction and movement speed.
        GetComponent<Rigidbody>().velocity = moveSpd * Time.deltaTime * transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            // Call the "Kill" method on the Player script and destroy the player GameObject.
            other.GetComponent<Player>().Kill();
            Destroy(other.gameObject);
        }
    }

    public void Destroy() 
    {
        // Instantiate the removal GameObject at the current position with no rotation.
        var rmv = Instantiate(remove, transform.position, Quaternion.identity);
        Destroy(rmv);

    }
}
