using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCoinCollector : MonoBehaviour
{

    [SerializeField] private int _coinstInt;
    public int CoinstInt => _coinstInt;
    [SerializeField] private Text _currentCoinsCollector;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Coin coins))
        {
            _coinstInt++;
            _currentCoinsCollector.text = _coinstInt.ToString();
            Destroy(coins.gameObject);
        }
    }
}
