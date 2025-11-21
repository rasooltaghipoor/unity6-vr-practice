using UnityEngine;
using UnityEngine.Events;

public class TriggerZone : MonoBehaviour
{
    public string targetTag;
    public UnityEvent<GameObject> OnEnterEvent;
    
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == targetTag)
            OnEnterEvent.Invoke(other.gameObject);
    }
}
