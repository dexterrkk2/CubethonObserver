using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRandomizer : MonoBehaviour
{
    public MeshRenderer mat;
    public List<Color> colors;
    // Start is called before the first frame update
    void Start()
    {
        int random = Random.Range(0, colors.Count);
        mat.material.color = colors[random];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
