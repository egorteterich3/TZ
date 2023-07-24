using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] public GameObject levelChanger;

    public void OnClickStart()
    {
        levelChanger.SetActive(true);
    }

    public void OnClickExit()
    {
        Application.Quit();
    }

    public void ChangeLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

}
