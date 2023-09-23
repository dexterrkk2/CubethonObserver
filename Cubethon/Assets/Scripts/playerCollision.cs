using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour
{
    public PlayerMovement playerMvmnt;
    public delegate void HitObstacle(Collision collisionInfo);
    public static event HitObstacle onHitObstacle;
    private void Start()
    {
        playerMvmnt.enabled = true;
    }
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            if (onHitObstacle != null)
            {
                onHitObstacle(collisionInfo);
            }
        }
        else if(collisionInfo.collider.tag == "Ground")
        {
            playerMvmnt.jump = true;
        }
    }
}
