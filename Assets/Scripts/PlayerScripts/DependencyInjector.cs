using UnityEngine;
public class DependencyInjector : MonoBehaviour
{
    void Start()
    {
        PlayerCharacter playerCharacter = FindObjectOfType<PlayerCharacter>();
        PlayerCharacterView playerCharacterView = FindObjectOfType<PlayerCharacterView>();
        PlayerCharacterPresenter playerCharacterPresenter = FindObjectOfType<PlayerCharacterPresenter>();

        playerCharacterPresenter.InjectDependencies(playerCharacter, playerCharacterView);
    }
}
