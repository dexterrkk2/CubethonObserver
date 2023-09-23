using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Text scoreText;
    // Update is called once per frame
    void OnEnable()
    {
        PlayerMovement.onMove += UpdateScore;
    }
    private void OnDisable()
    {
        PlayerMovement.onMove -= UpdateScore;
    }
    public void UpdateScore(Vector3 player)
    {
        scoreText.text = player.z.ToString("0");
    }
}
