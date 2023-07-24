using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{

    [SerializeField] private int _hp = 1;
    private PlayerHealth _playerHealth;

    private void Start()
    {
        _playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerHealth>() && _playerHealth.Health < _playerHealth.MaxHealth)
        {
            _playerHealth.AddHealth(_hp);
            Destroy(gameObject);
        }
    }
}
