using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{
    public GameObject rangeparticle;
    public GameObject canvaslow;
    PlayerHealth PlayerHealthplayerHealth;
    HealthBar healthbar;
    // Start is called before the first frame update
    void Start()
    {
        PlayerHealthplayerHealth = FindObjectOfType<PlayerHealth>();
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rangeparticle.SetActive(false);
            canvaslow.SetActive(false);
            StopAllCoroutines();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rangeparticle.SetActive(true);
            canvaslow.SetActive(true);
            StartCoroutine(damage());
        }
    }
    IEnumerator damage()
    {
        yield return new WaitForSeconds(1);
        healthbar = FindObjectOfType<HealthBar>();
        healthbar.GetDamage(0.001f,0.1f);
    }
}
