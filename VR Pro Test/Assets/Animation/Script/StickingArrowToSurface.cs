using DamageNumbersPro;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.AI;

public class StickingArrowToSurface : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private SphereCollider myCollider;

    [SerializeField]
    private GameObject stickingArrow;

    public bool isTimerActive= false;

    private int injuryCheckHash = Animator.StringToHash("InjuryCheck");

    float timer;
    public GameObject highdamage;
    public bool on;
    public DamageNumber numberPrefab;



    void Start()
    {
        timer = 0;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.isKinematic = true;
        myCollider.isTrigger = true;

        GameObject arrow = Instantiate(stickingArrow);
        arrow.transform.position = transform.position;
        arrow.transform.forward = transform.forward;
        
        
        if (myCollider.isTrigger == true && collision.gameObject.tag == "Enemy")
        {                   
            Transform childTransform = arrow.transform.Find("Magic hit");
            GameObject childObject = childTransform.gameObject;
            Transform childTransform1 = arrow.transform.Find("Punch Hit");
            GameObject childObject1 = childTransform1.gameObject;
            Enemy enemy = collision.transform.root.GetComponent<Enemy>();
            ArrowController count = FindObjectOfType<ArrowController>();
            count.hitcount++;
            HealthBar healthBar = FindObjectOfType<HealthBar>(); 
            HandDamage HD=FindAnyObjectByType<HandDamage>();
            if (enemy != null && count.hitcount  <=2) {
                childObject.SetActive(false);
                childObject1.SetActive(true);
                enemy.GetDamage(0.5f); 
                healthBar.GetPower(0.5f);
                DamageNumber damageNumber = numberPrefab.Spawn(transform.position, 50);
                HD.handpower = true;
            }
            if (enemy != null && count.hitcount >2) 
            {
                childObject.SetActive(true);
                childObject1.SetActive(false);
                enemy.GetDamage(1);
                count.hitcount = 0;
                count. power = false;
                healthBar.GetPower(-1);
                DamageNumber damageNumber = numberPrefab.Spawn(transform.position, 100,Color.red);
                HD.handpower = false;
            }

            

        }
        if (myCollider.isTrigger == true && collision.gameObject.tag == "Enemy1")
        {
            Transform childTransform = arrow.transform.Find("Magic hit");
            GameObject childObject = childTransform.gameObject;
            Transform childTransform1 = arrow.transform.Find("Punch Hit");
            GameObject childObject1 = childTransform1.gameObject;
            Enemy1 enemy = collision.transform.root.GetComponent<Enemy1>();
            ArrowController count = FindObjectOfType<ArrowController>();
            count.hitcount++;
            HealthBar healthBar = FindObjectOfType<HealthBar>();
            if (enemy != null && count.hitcount <= 2) 
            { 
                childObject.SetActive(false); childObject1.SetActive(true); enemy.GetDamage(0.5f); healthBar.GetPower(0.5f);
                DamageNumber damageNumber = numberPrefab.Spawn(transform.position, 50);
            }
            if (enemy != null && count.hitcount > 2)
            {
                childObject.SetActive(true);
                childObject1.SetActive(false);
                enemy.GetDamage(1);
                count.hitcount = 0;
                count.power = false;
                healthBar.GetPower(-1);
                DamageNumber damageNumber = numberPrefab.Spawn(transform.position, 100, Color.red);
            }

        }
        if (myCollider.isTrigger == true && collision.gameObject.tag == "Enemy2")
        {
            Transform childTransform = arrow.transform.Find("Magic hit");
            GameObject childObject = childTransform.gameObject;
            Transform childTransform1 = arrow.transform.Find("Punch Hit");
            GameObject childObject1 =childTransform1.gameObject;
            Enemy2 enemy = collision.transform.root.GetComponent<Enemy2>();
            ArrowController count = FindObjectOfType<ArrowController>();
            count.hitcount++;
            HealthBar healthBar = FindObjectOfType<HealthBar>();
            if (enemy != null && count.hitcount <= 2) 
            { 
                childObject.SetActive(false); childObject1.SetActive(true); enemy.GetDamage(0.5f); healthBar.GetPower(0.5f);
                DamageNumber damageNumber = numberPrefab.Spawn(transform.position, 50);
            }
            if (enemy != null && count.hitcount > 2)
            {
                childObject.SetActive(true);
                childObject1.SetActive(false);
                enemy.GetDamage(1);
                count.hitcount = 0;
                count.power = false;
                healthBar.GetPower(-1);
                DamageNumber damageNumber = numberPrefab.Spawn(transform.position, 100, Color.red);
            }

        }
        /*if (myCollider.isTrigger == true && collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = FindObjectOfType<Enemy>();

            if (enemy != null) { enemy.GetDamage(50); }

        }*/

        if (myCollider.isTrigger == true && collision.gameObject.tag == "FatDroganHead")
        {
            FatDrogan enemy = FindObjectOfType<FatDrogan>();

            if (enemy != null) { enemy.GetDamage(50); }

        }
        if (myCollider.isTrigger == true && collision.gameObject.tag == "NIghtMare")
        {
            NightMare enemy = FindObjectOfType<NightMare>();

            if (enemy != null) { enemy.GetDamage(25); }

        }
        if (myCollider.isTrigger == true && collision.gameObject.tag == "DragonUsurper")
        {
            DragonUsurper enemy = FindObjectOfType<DragonUsurper>();

            if (enemy != null) { enemy.GetDamage(20); }

        }
        if (myCollider.isTrigger == true && collision.gameObject.tag == "TerrorBringer")
        {
            TerrorBringer enemy = FindObjectOfType<TerrorBringer>();

            if (enemy != null) { enemy.GetDamage(20); }

        }
        if (myCollider.isTrigger == true && collision.gameObject.tag == "Mav")
        {
           
            Maw enemy = FindObjectOfType<Maw>();
           /* enemy.agent.enabled = false;
            if (enemy.agent.enabled==false)
            {
                enemy.animator.SetBool("InjuryCheck", true);
                StartCoroutine(hitMav());

            }*/
            if (enemy != null&&!isTimerActive)
            {/*
                timer++;
                enemy.agent.enabled = false;
                enemy.animator.SetBool("InjuryCheck", true);
                Debug.Log(timer);
                if (timer >= 5) 
                {
                    
                    enemy.agent.enabled = true;
                    enemy.animator.SetBool("InjuryCheck", false);
                    Debug.Log("hh");
                } */
                //StartCoroutine(HitMavCoroutine(enemy));
                isTimerActive = true;
                StartCoroutine(HitMavCoroutine(enemy));
            }



            if (enemy != null) { enemy.GetDamage(20); }
            


        }
        if (collision.collider.attachedRigidbody != null)
        {

            arrow.transform.parent = collision.collider.attachedRigidbody.transform;


        }
       
       
        /*if (myCollider.isTrigger == true&&collision.gameObject.tag=="Enemy")
        {
            Debug.Log("ok");
            Enemy enemy = collision. gameObject.GetComponent<Enemy>();
            
                if(enemy != null) { enemy.GetDamage(10); }
            
            // gameObject.GetComponent<IHittable1>()?.GetDamage(10);
           // Enemy.Instance.GetDamage(10);

        }*/
        // collision.collider.GetComponent<IHittable1>()?.GetDamage(10); }

        //collision.collider.GetComponent<IHittable>()?.GetHit();

        // Enemy enemy = gameObject.GetComponent<Enemy>();
       /* if (enemy != null)
        {
            enemy.GetDamage(10);
        }*/


        Destroy(gameObject);
        Destroy(arrow.gameObject,10);

    }
    /*private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = gameObject.GetComponent<Enemy>();

        if (other.gameObject.tag=="Enemy")
        {
            enemy.GetDamage(10);
        }
    }*/

    IEnumerator HitMavCoroutine (Maw enemy)
    {
       // yield return new WaitForSeconds(3);
       // enemy.animator.SetBool("InjuryCheck", false);
       // enemy.agent.enabled = true;

        enemy.agent.enabled = false;
        enemy.animator.SetBool(injuryCheckHash, true);

        yield return new WaitForSeconds(5);

        enemy.agent.enabled = true;
        enemy.animator.SetBool(injuryCheckHash, false);

        isTimerActive = false;
    }
    public void hit()
    {
        Debug.Log("fff");
       
    }
}
