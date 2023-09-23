using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public delegate void LevelChange();
    public static event LevelChange levelTrigger;
    // Start is called before the first frame update
    void OnTriggerEnter()
    {
        if (levelTrigger != null)
        {
            levelTrigger();
        }
    }
}
