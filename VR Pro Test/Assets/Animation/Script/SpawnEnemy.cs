using RootMotion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject Dummy;
    public Transform spawnPoints;
   

   // public int dummiesSpawned = 0;

   /// <summary>
   //public float spawnDelay = 8f;
   /// </summary>
    // Start is called before the first frame update
    void Start()
    {
         spawn();
       

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawn()
    {
        /* if (dummiesSpawned < 2)
         {
             //int randomIndex = Random.Range(0, spawnPoints.Length);

            // Transform selectedSpawnPoint = spawnPoints[randomIndex].transform;


             dummiesSpawned++;
             Invoke("spawn", spawnDelay);
         }*/
        StartCoroutine(spawwing());
       // int randomDummy = Random.Range(0, Dummy.Length);
       // Transform selectedDummy = Dummy[randomDummy].transform;
       

    }
    /*
        public GameObject[] DummyPrefabs; // Array of different Dummy prefabs
        public Transform[] spawnPoints;
        public float spawnInterval = 2.0f;

        private int currentSpawnIndex = 0;
        private int currentDummyPrefabIndex = 0;
        private GameObject currentSpawnedDummy;

        // Start is called before the first frame update
        void Start()
        {
            // Start the coroutine to manage the spawning cycle
             StartCoroutine(SpawnCycle());
            SpawnDummy();
        }

        // Coroutine to manage the spawning cycle
        private IEnumerator SpawnCycle()
        {
            while (true) // This will keep running the spawning cycle indefinitely
            {
                if (currentSpawnedDummy == null)
                {
                    SpawnDummy();
                }
                yield return new WaitForSeconds(spawnInterval);
            }
        }

        // Method to spawn a single instance of the Dummy prefab
        public void SpawnDummy()
        {
            int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);
            int randomDummyPrefabIndex = (currentDummyPrefabIndex + 1) % DummyPrefabs.Length;

            Transform selectedSpawnPoint = spawnPoints[randomSpawnPointIndex];
            GameObject selectedDummyPrefab = DummyPrefabs[randomDummyPrefabIndex];

            currentSpawnedDummy = Instantiate(selectedDummyPrefab, selectedSpawnPoint.position, Quaternion.identity);
            currentDummyPrefabIndex = randomDummyPrefabIndex;
        }*/

    IEnumerator spawwing()
    {
        yield return new WaitForSeconds(9);
        Instantiate(Dummy, spawnPoints.position, Quaternion.identity);
    }
}
