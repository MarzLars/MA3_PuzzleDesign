using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField]
    private Animator doorAnimator;

    public void OpenDoor()
    {
        doorAnimator.SetBool("isOpen", true);
    }
}