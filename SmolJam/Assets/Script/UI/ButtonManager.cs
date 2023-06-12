using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
    [SerializeField]GameObject htpScreen;
    public void startGame()
    {
        SceneManager.LoadScene("Map1");
    }
    public void GotoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void howToPlayScreen()
    {
        htpScreen.SetActive(true);
    }
    public void exitHowToPlayScreen()
    {
        htpScreen.SetActive(false);
    }
}
