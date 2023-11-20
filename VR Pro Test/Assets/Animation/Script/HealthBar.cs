using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public float health = 1;
    public float maxHealth = 1;

    public float powerHit=0;
    public float MaxpowerHit=1;

    public Image Bar;
    public Image PowerBar;

    public float healthtextvalue = 100;
    public TextMeshProUGUI Healthtext;

    public TextMeshProUGUI    MaxpowerText;

    PlayerHealth ph;
    // Start is called before the first frame update
    void Start()
    {
        ph=FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0.3)
        {
            ph.lowtrue();

        }
        if (health >= 0.3)
        {
            ph.lowfalse();

        }
    }
    public void GetDamage(float amount,float textamount)
    {
        healthtextvalue -= textamount;
        Healthtext.text = healthtextvalue.ToString("F1");
        health -= amount;
        Bar.fillAmount = health / maxHealth;
        if (health <= 0)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene("GameOver");

        }
        

    }
    public void GetPower(float amount)
    {
        powerHit += amount;
        PowerBar.fillAmount=powerHit/ MaxpowerHit;
        if (powerHit == 1) { MaxpowerText.text = "Power Up";  }else MaxpowerText.text = "";

    }
}
