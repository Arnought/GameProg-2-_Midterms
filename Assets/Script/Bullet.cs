using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        // Apply an initial force to propel the object forward.
        rigidBody.AddForce(transform.forward * 1500);

        // Set the object's color to match the color of the player's current color selection.
        GetComponent<Renderer>().material.color = GameManager.Instance.colors[GameManager.Instance.PlayerTag().GetComponent<Switch>().index];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Check if this object and the enemy have the same color.
            if (SameColor(other.GetComponent<Enemy>().mat)) 
            {
                // Call the 'Destroy' method on the Enemy script and destroy the enemy GameObject.
                other.GetComponent<Enemy>().Destroy();
                Destroy(other.gameObject);
            }
            Destroy(gameObject);
        }
        
    }

    // Method to check if this object has the same color as the provided material.
    bool SameColor(Material mats) 
    { 
        var mat = GetComponent<Renderer>().material;

        // Compare the colors of the two materials and return the result.
        return mat.color.Equals(mats.color);
    }
}
