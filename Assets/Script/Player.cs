using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int detect;
    public LayerMask mask;
    public float area = 5f;
    private Collider[] collide = new Collider[20];
    private float rotSpeed = 15f;
    private GameObject target;
    float close;
    
    private void Update()
    {
        target = Fire();

        // If a target is found, rotate toward it.
        if (target != null) 
        {
            var on = target.transform.position - transform.position;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(on), rotSpeed * Time.deltaTime);
        }
    }

    private void OnMouseDown()
    {
        // Trigger a color change by calling the ChangeColors() method from the Switch script.
        GetComponent<Switch>().ChangeColors();
    }

    private GameObject Fire() 
    {
        // Perform a capsule-shaped overlap detection and store the number of detected objects in 'detect'.
        detect = Physics.OverlapCapsuleNonAlloc(transform.position, Vector3.one, area, collide, mask);

        // Initialize variables to store the nearest object and its distance.
        GameObject near = null;
        close = 0;

        // If objects were detected, find the nearest one.
        if (detect > 0) 
        {
            near = collide[0].gameObject;
            close = Vector3.Distance(transform.position, near.transform.position);
        }

        // Iterate through the detected objects to find the closest one.
        for (int i = 0; i < detect; i++) 
        {
            var cld = collide[i].gameObject;
            float position = Vector3.Distance(transform.position, cld.transform.position);

            // Update the nearest object if a closer one is found.
            if (position < close) 
            { 
                close = position;
                near = cld;
            }
        }

        return near;
    }

    public void Kill()
    {
        // Trigger the GameManager to update the game status.
        GameManager.Instance.GameStatus(true);
    }

    // This method is automatically called in the Unity editor and draws a red wireframe sphere to visualize the detection area.
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, area);
    }
}
