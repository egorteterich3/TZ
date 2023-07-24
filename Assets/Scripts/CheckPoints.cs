using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CheckPoints : MonoBehaviour
{
    [SerializeField] private List<CheckPoint> checkPoints;
    [SerializeField] private Vector3 vectorPoint;
    private PlayerHealth _playerHealth;

    [SerializeField] private float dead;

    private void Start()
    {
        _playerHealth = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (gameObject.transform.position.y < -dead)
        {
            gameObject.transform.position = vectorPoint;
            _playerHealth.TakeDamage(1);
        }
        //if(gameObject.transform.position != vectorPoint)
        //{
        //    if (gameObject.transform.position.y < -dead)
        //    {
        //        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //    }
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out CheckPoint point))
        {
            vectorPoint = gameObject.transform.position;
        }

        //if(gameObject.transform.TryGetComponent(out Ground ground))
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //}
    }
}
