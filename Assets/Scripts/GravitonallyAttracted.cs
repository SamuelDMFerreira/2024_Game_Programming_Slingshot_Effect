using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitonallyAttracted : MonoBehaviour
{
    private bool attracted = true;
    public bool Attracted 
    { 
        get => attracted; 
        set {attracted = value;} 
    }
}
