using UnityEngine;
using UnityEngine.Events;

namespace Puzzle.MA2_puzzle
{
    public class PlayPuzzleAnim : MonoBehaviour
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
}