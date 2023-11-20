using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy2 : MonoBehaviour
{
    public GameObject Dummy;
    public Transform spawnPoints;
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

        StartCoroutine(spawwing());


    }
    IEnumerator spawwing()
    {
        yield return new WaitForSeconds(10);
        Instantiate(Dummy, spawnPoints.position, Quaternion.identity);
    }
}
