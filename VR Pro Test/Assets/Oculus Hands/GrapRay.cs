using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrapRay : MonoBehaviour
{
    public GameObject leftGrabray;
    public GameObject rightGrabray;

    public XRDirectInteractor leftDirectGrab;
    public XRDirectInteractor rightDirectGrab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       leftGrabray.SetActive(leftDirectGrab.interactablesSelected.Count==0); 
       rightGrabray.SetActive(rightDirectGrab.interactablesSelected.Count==0); 
    }
}
