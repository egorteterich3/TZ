using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagementScene : MonoBehaviour
{
    public void RestartLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextScene(int scene)
    {
        SceneManager.LoadScene(scene + 1);
    }

    public void FinishAndStartGame()
    {
        SceneManager.LoadScene(1);
    }
}
