using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateTeleport : MonoBehaviour
{
    public GameObject leftTele;
    public GameObject rightTele;

    public InputActionProperty leftActive;
    public InputActionProperty rightActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leftTele.SetActive(leftActive.action.ReadValue<float>()>0.1f);
        rightTele.SetActive(rightActive.action.ReadValue<float>()>0.1f);
    }
}
