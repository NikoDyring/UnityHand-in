using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        private GameObject optionsWindow;
        [SerializeField]
        private GameObject mainWindow;

        /// <summary>
        /// Starts the game.
        /// </summary>
        public void PlayGame()
        {
            SceneManager.LoadScene("Level_01");
        }

        /// <summary>
        /// Opens the option menu.
        /// </summary>
        public void OpenOptions()
        {
            mainWindow.SetActive(false);
            optionsWindow.SetActive(true);
        }

        /// <summary>
        /// Save options by using player preferences.
        /// </summary>
        public void SaveOptions()
        {
            // TODO: Implement Playerprefs here.
            optionsWindow.SetActive(false);
            mainWindow.SetActive(true);
        }

        /// <summary>
        /// Quit the game.
        /// </summary>
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
