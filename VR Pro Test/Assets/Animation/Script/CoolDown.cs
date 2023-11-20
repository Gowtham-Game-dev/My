using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDown : MonoBehaviour
{
    public float timer=0;
    public float Maxtimer=30;
    public Image Coolfill;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar b = FindObjectOfType<HealthBar>();
        if (timer < Maxtimer)
        {
            timer += Time.deltaTime; 
            CoolDowwn();
        }
        if(timer>=Maxtimer&&b.health<1 && b.healthtextvalue < 100)
        { 
            b.health=1f; b.Bar.fillAmount = b.health / b.maxHealth; b.healthtextvalue = 100f; b.Healthtext.text = b.healthtextvalue.ToString(); 
            if(b.health>=1&&b.healthtextvalue>=100) { return; }
        }

    }
    public void CoolDowwn()
    {
        
        Coolfill.fillAmount = timer / Maxtimer;
    }
}
