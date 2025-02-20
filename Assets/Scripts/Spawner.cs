using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnTime = 1;
    public Zombie spawnZombie;
    public Transform[] spawnPoints;
    private float timer;
    public PlayerManager player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while (player.currentHealth > 0)
        {
            if (timer > spawnTime)
            {
                Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                Instantiate(spawnZombie, randomPoint.position, randomPoint.rotation);
                timer = 0;
            }

            timer += Time.deltaTime;
        }
    }
}
