using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class OpenDoor : MonoBehaviour
{
    public XRLever level;
    public Animator animator;
    private bool _isOpen;
    private string _boolName = "Open";
    [SerializeField] private AudioClip openDoorSound;

    // Update is called once per frame
    void Update()
    {
        _isOpen = animator.GetBool(_boolName);
        if (level.value && !_isOpen)
        {
            animator.SetBool(_boolName, true);
            SoundManager.Instance.PlayEffect(openDoorSound);
        }
        else if (!level.value && _isOpen)
        {
            animator.SetBool(_boolName, false);
            SoundManager.Instance.PlayEffect(openDoorSound);
        }
    }
}
