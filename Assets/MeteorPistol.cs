using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class MeteorPistol : MonoBehaviour
{
    public ParticleSystem particles;
    public LayerMask layerMask;
    public Transform shootSource;
    public float distance = 10;
    private bool rayActivate = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(x => StartShooting());
        grabInteractable.deactivated.AddListener(x => StopShooting());
    }

    void Update()
    {
        if (rayActivate)
            RaycastCheck();
    }

    public void StartShooting()
    {
        particles.Play();
        rayActivate = true;
    }

    public void StopShooting()
    {
        particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        rayActivate = false;
    }

    private void RaycastCheck()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(shootSource.position, shootSource.forward, out hit, distance, layerMask);
        if (hasHit)
            hit.transform.gameObject.SendMessage("Break", SendMessageOptions.DontRequireReceiver);        
    }
} 
