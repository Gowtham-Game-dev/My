using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCover : MonoBehaviour
{
    public GameObject coverObjectPrefab;
    public Transform[] spawnPoints;
    private GameObject currentCoverObject;
    private bool coverSpawned = false;
    private bool coverSpawned1 = false;
    private float basesize ;
    public float blinkDuration = 0.5f;
    public int blinkCount = 3;
    private Renderer renderer1;
    public Material newMaterial;

    // Start is called before the first frame update
    void Start()
    {
        basesize = transform.localScale.x;
        
        StartCoroutine(SpawnCoverPeriodically());

    }
    private void Update()
    {
        if (coverSpawned1)
        {
            StartCoroutine(color());
            coverSpawned1 = false;  
        }
        
    }
    IEnumerator SpawnCoverPeriodically()
    {
        while (true)
        {
            if (!coverSpawned)
            {
                int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);
                Transform selectedSpawnPoint = spawnPoints[randomSpawnPointIndex];

                // Disable the current coverObject if it exists
                if (currentCoverObject != null)
                {
                    coverSpawned1=true;
                    
                }
                if (currentCoverObject == null)
                {
                    currentCoverObject = Instantiate(coverObjectPrefab, selectedSpawnPoint.position, selectedSpawnPoint. transform.rotation);
                    currentCoverObject.GetComponent<Renderer>().sharedMaterial.color = Color.white;
                    coverSpawned = true;
                }  
                  
            }

            yield return new WaitForSeconds(7);
            coverSpawned = false;
       
    }
    }
    IEnumerator color()
    {
 
        yield return new WaitForSeconds(3);

        Renderer renderer = currentCoverObject.GetComponent<Renderer>();
       // Color originalColor = renderer.sharedMaterial.color = Color.red;

        renderer1 = currentCoverObject.GetComponent<Renderer>();
        Material originalMaterial = renderer1.material;
        renderer1.material = newMaterial;
       // renderer1.material = originalMaterial;
        // Change to transparent
       // renderer.material.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        

        // Blinking effect
        for (int i = 0; i < blinkCount; i++)
        {
            renderer1.enabled = false;
            yield return new WaitForSeconds(blinkDuration / 2);
            renderer1.enabled = true;
            yield return new WaitForSeconds(blinkDuration / 2);
        }

        // Change back to original color
       // renderer1.material.color = originalColor;

        Destroy(currentCoverObject,1);
    }
}
