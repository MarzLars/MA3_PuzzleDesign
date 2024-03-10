using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterView : MonoBehaviour, IPlayerCharacterView
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private AudioSource jumpSound;

    private void Start()
    {
        Cursor.visible = false;
    }
    public void UpdateMovementAnimation(Vector2 movementVector)
    {
        animator.SetFloat("Speed", Mathf.Abs(movementVector.y));
        animator.SetFloat("Strafe", Mathf.Abs(movementVector.x));
    }

    public void TriggerJumpAnimation()
    {
        animator.SetTrigger("Jump");
    }
    public void DoJump()
    {
        jumpSound.Play();
    }
}
