using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Material mat;
    public List<Color> colors;
    // Start is called before the first frame update
    void OnEnable()
    {
        MovementEvents.celebrate += ColorChange;
    }

    // Update is called once per frame
    void OnDisable ()
    {
        MovementEvents.celebrate -= ColorChange;
    }
    void ColorChange()
    {
        
    }
}
