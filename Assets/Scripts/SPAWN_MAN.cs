using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPAWN_MAN : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public int animalIndex;

    private float spawnRangeX = 14; //determina el rang que podrà aparéixer s'animal ( --><--)
    private float spawnPosZ = 15; // determina el rang que podrà aparéixer s'animal (adalt, abaix)

    public float startDelay = 2f;
    public float spawnInterval = 1.5f;

    private void Start() //un animal cada 1.5segons
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }


    private void SpawnRandomAnimal() //animal aleatori
    {
        animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], RandomSpawnPos(), animalPrefabs[animalIndex].transform.rotation);
    }


    private Vector3 RandomSpawnPos() //lloc aleatòri
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        return new Vector3(randomX, 0, spawnPosZ);

    }
}