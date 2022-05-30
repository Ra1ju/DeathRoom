using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawnpositions;

    private float timer = 0;

    [SerializeField]
    private float limit = 5f;

    [SerializeField]
    private float Spawnlimit = 2f;

    public GameObject enemy;
    private void Start()
    {
        int rand = Random.Range(0, spawnpositions.Length);
        Instantiate(enemy, spawnpositions[rand]);
        timer = 0;
    }
    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= limit)
        {
            for (int i = 0; i < Spawnlimit; i++)
            {
                int rand = Random.Range(0, spawnpositions.Length);
                Instantiate(enemy, spawnpositions[rand]);
                timer = 0;
            }
            int random = Random.Range(0, 10);
            if (Spawnlimit < 5 && random < 5)
            {
                Spawnlimit++;
            }
            
        }
    }
}
