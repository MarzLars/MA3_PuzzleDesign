using UnityEngine;
using UnityEngine.Playables;

//Sctipt based on https://learn.unity.com/tutorial/starting-timeline-through-a-c-script-2019-3#
namespace Puzzle.MA2_puzzle
{
    public class PlayTimeLineDoorOpen : MonoBehaviour
    {
        [SerializeField]
        private PlayableDirector director;
        private void Awake()
        {
            director = GetComponent<PlayableDirector>();
        }
        public void StartTimeline()
        {
            director.Play();
        }
    }
}
