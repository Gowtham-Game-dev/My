using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHealth : MonoBehaviour
{
    HealthBar healthBar;
    public SphereCollider colider;
    GameObject player;
    AudioSource PlayerHit;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        PlayerHit = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar = FindObjectOfType<HealthBar>();
        if (healthBar != null)
        {
            return;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Partical")
        {

            healthBar.GetDamage(0.1f, 10);
            PlayerHit.Play();
            CoolDown cool = FindAnyObjectByType<CoolDown>();
            cool.timer = 0;
            Debug.Log("oo");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        HandDamage hd = FindObjectOfType<HandDamage>();
        if (other.gameObject.tag=="bow") { hd.trig = false; } 
    }
    private void OnTriggerExit(Collider other)
    {
        HandDamage hd = FindObjectOfType<HandDamage>();
        if (other.gameObject.tag == "bow") { hd.trig = true; } 
    }
}
