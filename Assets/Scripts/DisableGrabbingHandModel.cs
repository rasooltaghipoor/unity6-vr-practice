using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class DisableGrabbingHandModel : MonoBehaviour
{   
    public GameObject leftHandModel;
    public GameObject rightHandModel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(HideGrabbgingHand);
        grabInteractable.selectExited.AddListener(ShowGrabbingHand);
    }

    void HideGrabbgingHand(SelectEnterEventArgs args)
    {
        if(args.interactorObject.transform.tag == "Left Hand")
            leftHandModel.SetActive(false);
        else if(args.interactorObject.transform.tag == "Right Hand")
            rightHandModel.SetActive(false);
    }

    void ShowGrabbingHand(SelectExitEventArgs args)
    {
        if(args.interactorObject.transform.tag == "Left Hand")
            leftHandModel.SetActive(true);
        else if(args.interactorObject.transform.tag == "Right Hand")
            rightHandModel.SetActive(true);
    }
}
