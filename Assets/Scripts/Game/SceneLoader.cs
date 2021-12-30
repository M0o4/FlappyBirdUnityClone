using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private int _sceneIndex;
        [SerializeField] private bool _currentScene;

        public void LoadScene()
        {
            if (_currentScene)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                return;
            }
            
            SceneManager.LoadScene(_sceneIndex);
        }
    }
}
