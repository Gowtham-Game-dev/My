using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XROffsetGrabInteractable : XRGrabInteractable
{
    private Vector3 initialLocalpos;
    private Quaternion initialLocalRot;
    // Start is called before the first frame update
    void Start()
    {
        if (!attachTransform)
        {
            GameObject attachpoint = new GameObject("offset Grap Pivot");
            attachpoint.transform.SetParent(transform, false);
            attachTransform = attachpoint.transform;
        }
        else
        {
            initialLocalpos=attachTransform.localPosition;
            initialLocalRot=attachTransform.localRotation;
        }
    }
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if(args.interactorObject is XRDirectInteractor)
        {
            attachTransform.position = args.interactorObject.transform.position;
            attachTransform.rotation = args.interactorObject.transform.rotation;
        }
        else
        {
            attachTransform.localPosition= initialLocalpos;
            attachTransform.rotation = initialLocalRot;
        }
       

        base.OnSelectEntered(args);

    }
}
