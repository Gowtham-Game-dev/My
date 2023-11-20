using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }*/
    private void OnCollisionEnter(Collision collision)
    {
        // arrow = GameObject.FindWithTag("Arrow");
        if (collision.gameObject.tag == "damage")
        {
            
            Enemy enemy = gameObject.GetComponent<Enemy>();
            Debug.Log("fu");
            enemy.GetDamage(10);
        }
    }
}
