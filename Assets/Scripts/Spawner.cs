using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnTime = 1;
    public Zombie spawnZombie;
    public int numberOfZombies;
    private float timer;
    public PlayerManager player;

    public float xPos;
    public float zPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.currentHealth > 0 && numberOfZombies < 20)
        {
            if (timer > spawnTime)
            {
                float minRadius = 5f; 
                float maxRadius = 15f; 

                float angle = UnityEngine.Random.Range(0f, Mathf.PI * 2);

                float distance = UnityEngine.Random.Range(minRadius, maxRadius);

                float xPos = player.transform.position.x + Mathf.Cos(angle) * distance;
                float zPos = player.transform.position.z + Mathf.Sin(angle) * distance;

                Instantiate(spawnZombie, new Vector3(xPos, 0, zPos) , Quaternion.identity);
                timer = 0;
            }

            timer += Time.deltaTime;
        }
    }
}
