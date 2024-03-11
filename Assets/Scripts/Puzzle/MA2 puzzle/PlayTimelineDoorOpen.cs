using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

//Sctipt based on https://learn.unity.com/tutorial/starting-timeline-through-a-c-script-2019-3#
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
