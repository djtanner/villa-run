using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject coinPrefab;
    public int numberOfObjectsToSpawn;

    // Start is called before the first frame update
    void Start()
    {

        SpawnObjects();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void SpawnObjects() {

        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            Vector3 randomPosition = GetRandomPosition();
            if (IsValidSpawnPosition(randomPosition))
            {
                Instantiate(coinPrefab, randomPosition, Quaternion.identity);
            }
        }



    }


    Vector3 GetRandomPosition()
    {
        // Modify these values based on your maze ground size and position
        float minX = -20f;
        float maxX = 20f;
        float minZ = -20f;
        float maxZ = 20f;

        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);

        Vector3 randomPosition = new Vector3(randomX, 0f, randomZ);
        return randomPosition;
    }

    bool IsValidSpawnPosition(Vector3 position)
    {
        // Check if there's already an object at the position
        Collider[] colliders = Physics.OverlapSphere(position, 0.5f); // Adjust the radius as needed
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag("Obstacle"))
            {
                // An object is already present at this position
                return false;
            }
        }
        return true;
    }




}
