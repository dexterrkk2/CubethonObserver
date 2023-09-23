using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameHasEnded = false;
    public float restarDelay;
    public GameObject completeLevelUi;
    private void OnEnable()
    {
        playerCollision.onHitObstacle += EndGame;
        EndTrigger.levelTrigger += CompleteLevel;
    }
    private void OnDisable()
    {
        playerCollision.onHitObstacle -= EndGame;
        EndTrigger.levelTrigger -= CompleteLevel;
    }
    public void CompleteLevel()
    {
        completeLevelUi.SetActive(true);
        Debug.Log("Level won");
    }
    public void EndGame(Collision collisionInfo)
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            Invoke("Restart", restarDelay);
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
