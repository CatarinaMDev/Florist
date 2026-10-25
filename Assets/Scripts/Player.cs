using UnityEngine;
using UnityEngine.InputSystem;
public class Player : Character
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.wKey.wasPressedThisFrame)
        {
            Debug.Log("Pressed W-> Move up");
            
        }
        if (Keyboard.current != null && Keyboard.current.aKey.wasPressedThisFrame)
        {
            Debug.Log("Pressed A-> Move left");
           
        }
        if (Keyboard.current != null && Keyboard.current.sKey.wasPressedThisFrame)
        {
            Debug.Log("Pressed S-> Move down");
          
        }
        if (Keyboard.current != null && Keyboard.current.dKey.wasPressedThisFrame)
        {
            Debug.Log("Pressed D -> Move right");
            
        }
    }
}
