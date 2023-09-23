using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloonMovement : MonoBehaviour
{
    public int upMovement;
    public int selfDestructTime;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", selfDestructTime);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos= new Vector3( transform.position.x,transform.position.y+ (upMovement*Time.deltaTime), transform.position.z);
        transform.position = newPos;
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
