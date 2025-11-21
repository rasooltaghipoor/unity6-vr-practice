using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class SpaceOutsideController : MonoBehaviour
{
    public XRLever lever;
    public XRKnob knob;
    public float forwardSpeed;
    public float sideSpeed;
    private bool wasOn;
    [SerializeField] private AudioClip engineSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wasOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        float forwardVelocity = forwardSpeed * (lever.value ? 1 : 0);
        float sideVelocity = sideSpeed * (lever.value ? 1 : 0) * Mathf.Lerp(-1, 1, knob.value);
        Vector3 velocity = new Vector3(sideVelocity, 0, forwardVelocity);
        transform.position += velocity * Time.deltaTime;

        if (lever.value != wasOn)
        {
            wasOn = lever.value;
            if (lever.value)
                SoundManager.Instance.PlayMusic(engineSound);
            else
                SoundManager.Instance.StopMusic();
        }
    }
}
