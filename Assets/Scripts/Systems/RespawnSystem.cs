using UnityEngine;
using UnityEngine.SceneManagement;

namespace Systems
{
    public class RespawnSystem : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                // Reload the current scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}