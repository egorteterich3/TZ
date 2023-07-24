using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{   

    [SerializeField] private Renderer[] _renderer;
    [SerializeField] private int _health = 3;
    [SerializeField] private GameObject _panelDeath;

    [Header("Particle")]
    [SerializeField] private ParticleSystem _sparkExplosionBlue;
    [SerializeField] private ParticleSystem _sparkExplosionYellow;

    [Header("Health")]
    [SerializeField] private int numOfHearts;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

    [SerializeField] private PlayerMover _playerMover;

    private int _maxHealth = 3;
    public int MaxHealth => _maxHealth;
    public int Health => _health;

    private float _timer = 2f;

    private void Start()
    {
        //_playerMover = FindObjectOfType<PlayerMover>();
        _maxHealth = _health;
    }

    public void TakeDamage(int damage)
    {
        
        if(_health > numOfHearts)
        {
            _health = numOfHearts;
        }

        if (_playerMover.IsBall == true)
        {
            damage = 0;
            _health -= damage;
        }
        if(_playerMover.IsBall == false)
        {
            _health -= damage;
            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < Mathf.RoundToInt(_health))
                {
                    hearts[i].sprite = fullHeart;
                }
                else
                {
                    hearts[i].color = Color.gray;
                    hearts[i].sprite = fullHeart;
                }
            }
            for (int i = 0; i < _renderer.Length; i++)
            {
                _renderer[i].material.SetColor("_EmissionColor", new Color(0.3f, 0.3f, 0.3f, 0));
                _sparkExplosionBlue.Play();
                _sparkExplosionYellow.Play();
            }
            Invoke("ResetMaterial", 0.1f);
            if (_health <= 0)
            {
                _panelDeath.SetActive(true);
                _playerMover.enabled = false;
                Invoke("EnabledPanel", 2f);
                //Destroy(gameObject);
            }

        }
    }

    public void ResetMaterial()
    {
        for (int i = 0; i < _renderer.Length; i++)
        {
            _renderer[i].material.SetColor("_EmissionColor", new Color(0, 0, 0, 0));
        }
    }

    public void AddHealth(int hp)
    {
        _health += hp;
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Mathf.RoundToInt(_health))
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        } 
    }

    public void EnabledPanel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
