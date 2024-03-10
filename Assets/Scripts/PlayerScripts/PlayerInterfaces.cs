using UnityEngine;
using UnityEngine.InputSystem;

public interface IPlayerCharacterModel
{
    Vector2 MovementVector { get; set; }
    bool IsGrounded { get; }
    void Jump();
}
public interface IPlayerCharacterPresenter
{
    void HandleVectorMovementChanged(InputAction.CallbackContext inputActionContext);
    void HandleJumpTriggered(InputAction.CallbackContext inputActionContext);
}

public interface IPlayerCharacterView
{
    void UpdateMovementAnimation(Vector2 movementVector);
    void TriggerJumpAnimation();
}