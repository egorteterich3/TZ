using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsDisplay : MonoBehaviour
{

    [SerializeField] private Image[] stars;
    
    [SerializeField] int levelChanger = 0;
    [SerializeField] private Button[] _buttons;
    [SerializeField] private LockForLevel[] _lockForLevel;

    [SerializeField] private string keyName = "S";

    private MainMenu ms;

    private void Awake()
    {
        stars = GetComponentsInChildren<Image>();
        ms= Camera.main.GetComponent<MainMenu>();
        _buttons = ms.levelChanger.GetComponentsInChildren<Button>();
        _lockForLevel = ms.levelChanger.GetComponentsInChildren<LockForLevel>();
    }

    private void Start()
    {
        //PlayerPrefs.DeleteAll();

        if (PlayerPrefs.GetInt(keyName) == 3)
        {
            int unlockLevel = levelChanger + 1;
            _buttons[unlockLevel].interactable = true;
            _lockForLevel[unlockLevel].enabled = true;
            stars[1].color = new Color(stars[1].color.r, stars[1].color.g, stars[1].color.b, 255);
            stars[2].color = new Color(stars[2].color.r, stars[2].color.g, stars[2].color.b, 255);
            stars[3].color = new Color(stars[3].color.r, stars[3].color.g, stars[3].color.b, 255);
        }
        else if (PlayerPrefs.GetInt(keyName) == 2)
        {
            int unlockLevel = levelChanger + 1;
            _buttons[unlockLevel].interactable = true;
            _lockForLevel[unlockLevel].enabled = true;
            stars[1].color = new Color(stars[1].color.r, stars[1].color.g, stars[1].color.b, 255);
            stars[2].color = new Color(stars[2].color.r, stars[2].color.g, stars[2].color.b, 255);
        }
        else if (PlayerPrefs.GetInt(keyName) == 1)
        {
            stars[1].color = new Color(stars[1].color.r, stars[1].color.g, stars[1].color.b, 255);
        }

    }

}
