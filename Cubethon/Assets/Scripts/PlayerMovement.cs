using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce;
    public float sidewaysForce;
    public float jumpForce;
    public bool moveRight;
    public bool moveLeft;
    public bool jump;
    public delegate void DistanceEvent(Vector3 playerPosition);
    public static event DistanceEvent onMove;
    public void OnEnable()
    {
        playerCollision.onHitObstacle += Disable;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        if (moveRight)
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.Impulse);
        }
        if (moveLeft)
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0,ForceMode.Impulse);
        }
        moveLeft = false;
        moveRight = false;
    }
    private void Update()
    {
        if (Input.GetKey("a"))
        {
            moveLeft = true;
        }
        if (Input.GetKey("d"))
        {
            moveRight = true;
        }
        if (Input.GetKey("space")  && jump == true)
        {
            Debug.Log(jump);
            jump = false;
            Jump();
        }
        if(rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame(null);
        }
        if(onMove != null)
        {
            onMove(transform.position);
        }
    }
    void Jump()
    {
        Vector3 jumpPosition = new Vector3(transform.position.x, transform.position.y + jumpForce, transform.position.z);
        rb.MovePosition(jumpPosition);
    }
    public void Disable(Collision collision)
    {
        playerCollision.onHitObstacle -= Disable;
        if(this != null){
            this.enabled = false;
        }
    }
}
