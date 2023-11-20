using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimHand : MonoBehaviour
{
    public InputActionProperty Pinch;
    public InputActionProperty Grip;
    public Animator handAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       float trigger= Pinch.action.ReadValue<float>();
        handAnim.SetFloat("Trigger", trigger);

        float grip=Grip.action.ReadValue<float>();
        handAnim.SetFloat("Grip", grip);
    }
}
