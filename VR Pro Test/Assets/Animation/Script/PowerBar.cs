using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    public float health = 1;
    public float maxHealth = 1;

    public Image Bar;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GetDamage(float amount)
    {

        health -= amount;
        Bar.fillAmount = health / maxHealth;
        if (health <= 0)
        {
            Debug.Log("Game Over");

        }
    }
}
