using UnityEngine;
public class DependencyInjector : MonoBehaviour
{
    void Start()
    {
        //Method Object.FindObjectsOfType has been deprecated. Use Object.FindObjectsByType instead which lets you decide whether you need the results sorted or not.
        //FindObjectsOfType sorts the results by InstanceID but if you do not need this using FindObjectSortMode.None is considerably faster.
        PlayerCharacter playerCharacter = Object.FindFirstObjectByType<PlayerCharacter>();
        PlayerCharacterView playerCharacterView = Object.FindFirstObjectByType<PlayerCharacterView>();
        PlayerCharacterPresenter playerCharacterPresenter = Object.FindFirstObjectByType<PlayerCharacterPresenter>();

        playerCharacterPresenter.InjectDependencies(playerCharacter, playerCharacterView);
    }
}