using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Renderer render;
    public int index;
    void Start()
    {
        // Set the initial color of the object's material to the color at the specified index
        render.material.color = GameManager.Instance.colors[index];
    }

    public void ChangeColors() 
    {
        // Increment the color index, wrapping around to 0 if it exceeds the list's size.
        index = (index + 1) % GameManager.Instance.colors.Count;

        // Set the object's material color to the newly selected color.
        render.material.color = GameManager.Instance.colors[index];
    }

    void Update()
    {
        // Check for a mouse click (left mouse button) and call the 'ChangeColors' method.
        if (Input.GetKeyDown(KeyCode.Mouse0)) ChangeColors();
    }

}