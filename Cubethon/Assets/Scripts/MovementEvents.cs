using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEvents : MonoBehaviour
{
    public int balloonCount;
    public int celebrationGoal;
    public int reoccuringCelebration;
    public int xSpawnRange;
    public int ySpawnRange;
    public int zSpawnRange;
    public GameObject bloon;
    public Vector3 offset;
    public delegate void CelebrationEvent();
    public static event CelebrationEvent celebrate;
    // Start is called before the first frame update
    void OnEnable()
    {
        PlayerMovement.onMove += SpawnLoons;
    }
    void OnDisable()
    {
        PlayerMovement.onMove -= SpawnLoons;
    }
    public void SpawnLoons(Vector3 player)
    {
        if(player.z >= celebrationGoal)
        {
            
            for (int i = 0; i < balloonCount; i++)
            {
                int randomx = Random.Range(0, xSpawnRange);
                int randomy = Random.Range(0, ySpawnRange);
                int randomz = Random.Range(0, zSpawnRange);
                Vector3 random =new Vector3(randomx, randomy, randomz);
                Instantiate(bloon, player + offset+random, Quaternion.identity);
                if(celebrate != null)
                {
                    celebrate();
                }
            }
            if (reoccuringCelebration <= 0)
            {
                PlayerMovement.onMove -= SpawnLoons;
            }
            else
            {
                celebrationGoal += reoccuringCelebration;
            }
        }
    }
}
