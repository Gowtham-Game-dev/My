using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Ragdoll : MonoBehaviour
{
    public Animator ani;
    public  Rigidbody[] ragdollBodies;
    public Collider[] colliders;
    // Start is called before the first frame update
    void Start()
    {
        ragdollBodies= GetComponentsInChildren<Rigidbody>();
        colliders= GetComponentsInChildren<Collider>();

        ToggleRagdoll(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ToggleRagdoll(bool state)
    {
        ani.enabled= !state;
        foreach(Rigidbody rb in ragdollBodies) { rb.isKinematic=!state; }
        foreach(Collider collider in colliders) { collider.enabled = state; }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag=="object")
        {
            Debug.Log("ok");
        }
    }
}
