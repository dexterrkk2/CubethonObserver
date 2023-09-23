using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource wow;
    // Start is called before the first frame update
    void OnEnable()
    {
        MovementEvents.celebrate += PlaySound;
    }
    void OnDisable ()
    {
        MovementEvents.celebrate -= PlaySound;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySound()
    {
        wow.Play();
    }
}
