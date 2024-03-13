using UnityEngine;

namespace Puzzle.MA2_puzzle
{
    public class DoorController : MonoBehaviour
    {
        [SerializeField]
        private Animator doorAnimator;

        public void OpenDoor()
        {
            doorAnimator.SetBool("isOpen", true);
        }
    }
}