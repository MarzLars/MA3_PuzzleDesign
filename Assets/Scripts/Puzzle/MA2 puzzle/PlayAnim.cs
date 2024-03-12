using UnityEngine;
using UnityEngine.Events;

public class PlayAnim : MonoBehaviour
{
    [SerializeField]
    private Animator myAnimationController;

    public GameObject objectToEnable;
    public UnityEvent onTriggerEnterEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myAnimationController.SetBool("isPressed", true);
            objectToEnable.SetActive(true);

            onTriggerEnterEvent?.Invoke();
        }
    }
}