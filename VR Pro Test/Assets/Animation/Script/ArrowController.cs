using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;

public class ArrowController : MonoBehaviour
{
    [SerializeField]
    private GameObject midPointVisual, arrowPrefab, arrowSpawnPoint;

    [SerializeField]
    private float arrowMaxSpeed = 10;
    public float hitcount;
    public GameObject PowerArrow;
   public  bool power;

    private void Update()
    {
        
    }
    public void PrepareArrow()
    {
        midPointVisual.SetActive(true);
        if (hitcount == 2)
        {
            /*HealthBar HB= GetComponent<HealthBar>();
            HB.MaxpowerText.text = "Power Up";*/
            power = true;
            if (power) { 
                PowerArrow.SetActive(true);
               
                //Instantiate(PowerArrow, arrowSpawnPoint.transform.position, Quaternion.identity); 
                // power = false; hitcount = 0;
            }
           
        }
    }
    public void ReleaseArrow(float strength)
    {
           
        midPointVisual.SetActive(false);
        if (!midPointVisual.activeSelf && hitcount == 2)
        {
            PowerArrow.SetActive(false);
           
        }


        GameObject arrow = Instantiate(arrowPrefab);
        arrow.transform.position = arrowSpawnPoint.transform.position;
        arrow.transform.rotation = midPointVisual.transform.rotation;
        Rigidbody rb = arrow.GetComponent<Rigidbody>();
       
        rb.AddForce(midPointVisual.transform.forward * strength * arrowMaxSpeed, ForceMode.Impulse);

        
           
        

            //PowerArrow.SetActive(true);
            /* GameObject arrowParent = GameObject.FindWithTag("Arrow");
             if (arrowParent != null)
             {
                 Transform specificChild = arrowParent.transform.Find("Projectile 7"); 

                 if (specificChild != null)
                 {
                     specificChild.gameObject.SetActive(true);
                 }
             }*/

            // if (arrowParent != null) { arrowParent.GetChildGameObject().SetActive(false); }
            // GameObject newArrow = Instantiate(PowerArrow, arrow.transform.position, Quaternion.identity);
            // newArrow.transform.SetParent(arrow.transform);

            Destroy(arrow,10);

    }
    /* private void OnCollisionEnter(Collision collision)
     {
         // arrow = GameObject.FindWithTag("Arrow");
         if (collision.gameObject.tag == "Enemy")
         {

             Enemy enemy = gameObject.GetComponent<Enemy>();
             if (enemy != null)
             {

                 enemy.GetDamage(10);
                 Debug.Log("f");
             }
         }
     }*/
  /*  private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == null)
        {
            return;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.GetDamage(10);
                Debug.Log("fff");
            }
        }
    }*/
}
