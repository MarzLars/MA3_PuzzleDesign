using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerCharacterPresenter : MonoBehaviour, IPlayerCharacterPresenter
{
    private IPlayerCharacterModel playerCharacter;
    private IPlayerCharacterView playerCharacterView;

    //Dependency Injection
    public void InjectDependencies(IPlayerCharacterModel playerCharacter, IPlayerCharacterView playerCharacterView)
    {
        this.playerCharacter = playerCharacter;
        this.playerCharacterView = playerCharacterView;
    }
    public void HandleVectorMovementChanged(InputAction.CallbackContext inputActionContext)
    {
        Vector2 movementVector = inputActionContext.ReadValue<Vector2>();
        playerCharacter.MovementVector = movementVector;
        playerCharacterView.UpdateMovementAnimation(movementVector);
    }

    public void HandleJumpTriggered(InputAction.CallbackContext inputActionContext)
    {
        if (playerCharacter.IsGrounded && inputActionContext.phase == InputActionPhase.Started)
        {
            playerCharacter.Jump();
            playerCharacterView.TriggerJumpAnimation();
        }
    }
}