using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandDamage : MonoBehaviour
{
    HealthBar healthBar;
    AudioSource PlayerHit;
    public GameObject prefab;
    public GameObject prefab1;
    public Transform spawnpoint;
   // public Transform spawnpoint1;
    public bool handpower;
    public bool trig=true;
    public bool ins;
    private GameObject instantiatedPrefab;
    public InputActionProperty Pinch;
    private bool prevTriggerState = false;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
       
        healthBar = FindObjectOfType<HealthBar>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (handpower&& trig)
        {
            
            float trigger = Pinch.action.ReadValue<float>();
            if (trigger > 0 )
            {
                animator.SetBool("triggerr",true);
                prefab1.SetActive(true);
                ins= true;
                

                /*if (prevTriggerState && trigger == 0 && instantiatedPrefab == null) // Trigger was previously pressed and is now released
                {

                    instantiatedPrefab = Instantiate(prefab, spawnpoint.transform.position, spawnpoint.transform.rotation);
                }*/
            }
            else animator.SetBool("triggerr", false); 
            if(trigger == 0 && ins) 
            {
                prefab1.SetActive(false);
                instantiatedPrefab = Instantiate(prefab, spawnpoint.transform.position, spawnpoint.transform.rotation);
                Vector3 targetPosition = instantiatedPrefab.transform.position + Vector3.forward * Time.deltaTime;
                instantiatedPrefab.transform.position = Vector3.MoveTowards(instantiatedPrefab.transform.position, targetPosition, 5f);
                ins= false;
                    return;
                
            }
           


            // prevTriggerState = trigger > 0;
        }
    }
    

}
    /*private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Partical")
        {

            healthBar.GetDamage(0.1f,10);
            PlayerHit.Play();
        }
    }*/
    

