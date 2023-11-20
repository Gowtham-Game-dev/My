//using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    HealthBar healthBar;
    public GameObject lowhealth;
    GameObject player;
    AudioSource PlayerHit;

    private void Awake()
    {
       
    }
    // Start is called before the first frame update
    void Start()
    {
        /* Transform handTransform = transform.Find("Hands");

         if (handTransform != null)
         {
             Transform lefthandtransform = handTransform.Find("Left Hand");
             if (lefthandtransform != null)
             {
                 Transform modelparent = lefthandtransform.Find("[Left Hand] Model Parent");
                 if (modelparent != null)
                 {
                     Transform clone = modelparent.Find("LeftHand(Clone)");
                     if (clone != null)
                     {
                         Transform canvas = clone.Find("Canvas");
                         if (canvas != null)
                         {
                             Transform barTransform = canvas.Find("uf_bg_elite");
                             if (barTransform != null)
                             {
                                 Transform fillTransform = barTransform.Find("fill");
                                 if (fillTransform != null)
                                 {
                                     Bar = fillTransform.GetComponent<Image>();
                                     if (Bar == null)
                                     {
                                         Debug.LogError("Image component not found on 'Bar' object.");
                                     }



                                 }
                                 else Debug.LogError("Image component not found on 'fill' object.");

                             }
                             else Debug.LogError("Image component not found on 'barTransform' object.");

                         }
                         else Debug.LogError("Image component not found on 'canvas' object.");
                     }
                     else Debug.LogError("Image component not found on 'clone' object.");
                 }
                 else Debug.LogError("Image component not found on 'model' object.");
             }
             else Debug.LogError("Image component not found on 'lefthands' object.");
         }
         else Debug.LogError("Image component not found on 'hands' object.");*/


        player = GameObject.FindWithTag("Player");
        PlayerHit= GetComponent<AudioSource>();  
    }


    // Update is called once per frame
    void Update()
    {
        healthBar = FindObjectOfType<HealthBar>();
        if(healthBar!=null)
        {
            return;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Partical")
        {
           
            healthBar. GetDamage(0.1f,10);
            PlayerHit.Play();
            CoolDown cool=FindAnyObjectByType<CoolDown>();
            cool.timer = 0;
        }
    }
    public void lowtrue()
    {
        lowhealth.SetActive(true);
    }
    public void lowfalse()
    {
        lowhealth.SetActive(false);
    }

   
}
