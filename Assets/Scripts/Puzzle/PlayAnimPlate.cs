using UnityEngine;
using UnityEngine.Events;

public class PlayAnimPlate : MonoBehaviour
{
    [SerializeField]
    private Animator myAnimationController;

    public UnityEvent onTriggerEnterEvent;
    public GameObject objectToEnable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myAnimationController.SetBool("isPressed", true);
            onTriggerEnterEvent.Invoke();
            objectToEnable.SetActive(true);
        }
    }
}