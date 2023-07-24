using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishPlatform : MonoBehaviour
{

    private PlayerCoinCollector _playerCoinCollector;

    [SerializeField] private GameObject _finishPanel;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private Image[] stars = new Image[3];
    [SerializeField] private Text _coinsCount;

    [SerializeField] int cointTarget3 = 6; 
    [SerializeField] int cointTarget2 = 4;
    [SerializeField] int cointTarget1 = 2;

    [SerializeField] private string _keyName = "S";

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        _playerCoinCollector = FindObjectOfType<PlayerCoinCollector>();
        _playerMover = FindObjectOfType<PlayerMover>();
        Cursor.visible = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMover playerMover))
        {
            _coinsCount.text = "Собрано монет: " + _playerCoinCollector.CoinstInt.ToString();
            _finishPanel.SetActive(true);

            if(_playerCoinCollector.CoinstInt >= cointTarget3)
            {
                stars[0].color = new Color(stars[0].color.r, stars[0].color.g, stars[0].color.b, 255);
                stars[1].color = new Color(stars[1].color.r, stars[1].color.g, stars[1].color.b, 255);
                stars[2].color = new Color(stars[2].color.r, stars[2].color.g, stars[2].color.b, 255);
                PlayerPrefs.SetInt(_keyName, 3);
                PlayerPrefs.Save();
            }
            else if(_playerCoinCollector.CoinstInt >= cointTarget2 && _playerCoinCollector.CoinstInt != cointTarget3)
            {
                stars[0].color = new Color(stars[0].color.r, stars[0].color.g, stars[0].color.b, 255);
                stars[1].color = new Color(stars[1].color.r, stars[1].color.g, stars[1].color.b, 255);
                if(PlayerPrefs.GetInt(_keyName) != 3)
                {
                    PlayerPrefs.SetInt(_keyName, 2);
                    PlayerPrefs.Save();
                }
            }
            else if (_playerCoinCollector.CoinstInt >= cointTarget1 && _playerCoinCollector.CoinstInt != cointTarget2)
            {
                stars[0].color = new Color(stars[0].color.r, stars[0].color.g, stars[0].color.b, 255);
                if (PlayerPrefs.GetInt(_keyName) != 3 && PlayerPrefs.GetInt(_keyName) != 2)
                {
                    PlayerPrefs.SetInt(_keyName, 1);
                    PlayerPrefs.Save();
                }
            }

            _playerMover.enabled = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

}
