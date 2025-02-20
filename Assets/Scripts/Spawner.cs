using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnTime = 5;
    public GameObject spawnZombie;
    public int numberOfZombies;
    private float timer = 0;
    public PlayerManager player;

    private float xPos;
    private float zPos;
    float minRadius = 5f;
    float maxRadius = 15f;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.currentHealth > 0 && numberOfZombies < 20)
        {
            if (timer > spawnTime)
            {

                float angle = Random.Range(0f, Mathf.PI * 2);

                float distance = Random.Range(minRadius, maxRadius);

                float xPos = player.transform.position.x + Mathf.Cos(angle) * distance;
                float zPos = player.transform.position.z + Mathf.Sin(angle) * distance;

                Instantiate(spawnZombie, new Vector3(xPos, 0, zPos) , Quaternion.identity);
                timer = 0;
                numberOfZombies++;
            }

            timer += Time.deltaTime;
        }
    }
}
