using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerController controller;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controller != null)
        {
            // activate player commands using player input
            if (Input.GetKeyDown(KeyCode.Space))
            {
                controller.ApplyEscapeThrust();
            }
            // get player turn 
            float rotation = Input.GetAxis("Horizontal");
            controller.HandleInputRotation(rotation);
        }
    }
}
