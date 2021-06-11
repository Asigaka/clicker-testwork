using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //Переход на другие сцены
    public void MainMenuSceneLoad()
    {
        SceneManager.LoadScene(0);
    }
    public void GameSceneLoad()
    {
        SceneManager.LoadScene(1);
    }
    public void RecordsSceneLoad()
    {
        SceneManager.LoadScene(2);
    }
    public void CreditsSceneLoad()
    {
        SceneManager.LoadScene(3);
    }
    public void TutorialSceneLoad()
    {
        SceneManager.LoadScene(4);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
