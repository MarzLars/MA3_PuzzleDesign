using UnityEngine;
using UnityEngine.Events;

public class PlayAnimLever : MonoBehaviour
{
    [SerializeField]
    private Animator myAnimationController;

    public GameObject objectToEnable;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myAnimationController.SetBool("isPressed", true);
            objectToEnable.SetActive(true);
        }
    }
}