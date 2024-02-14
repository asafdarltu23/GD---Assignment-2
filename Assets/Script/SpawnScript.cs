using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject[] Enemies = new GameObject[3];
    public GameObject[] Boosts = new GameObject[5];
    int randomEntity;
    int Chance;

    float timer;
    float diffUpTime = 30;
    float spawnTimer;
    float spawnTime = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        spawnTimer += Time.deltaTime;

        if (spawnTimer > spawnTime)
        {
            Chance = Random.Range(0, 5);
            if (Chance < 4)
            {
                randomEntity = Random.Range(0, 3);
                Instantiate(Enemies[randomEntity], this.transform.position, Quaternion.identity);
            }
            else if (Chance > 3)
            {
                Chance = Random.Range(0, 17);
                Debug.Log(Chance);
                if (Chance < 16)
                {
                    randomEntity = Random.Range(0, 4);
                    Instantiate(Boosts[randomEntity], this.transform.position, Quaternion.identity);
                }
                else if (Chance > 15)
                {
                    Instantiate(Boosts[4], this.transform.position, Quaternion.identity);
                }
            }
            spawnTimer = 0;
        }

        if (timer > diffUpTime)
        {
            if (spawnTime > 1)
                spawnTime = spawnTime - 1;
            else
                spawnTime = spawnTime - 0.5f;
            timer = 0;
        }

        if (spawnTime < 0.5f)
        {
            spawnTime = 0.5f;
        }
    }
}
