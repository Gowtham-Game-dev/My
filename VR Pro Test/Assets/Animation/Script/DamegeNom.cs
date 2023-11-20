using DamageNumbersPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamegeNom : MonoBehaviour
{
    
    public DamageNumber numberPrefab;

    void Update()
    {
       
    }
    public void halfDameageNum()
    {
        DamageNumber damageNumber = numberPrefab.Spawn(transform.position, 50);
    }
    public void fullDameageNum()
    {
        DamageNumber damageNumber = numberPrefab.Spawn(transform.position, 100);
    }
}
