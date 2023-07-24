using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] cubes;
    [SerializeField] private GameObject[] spawnpos;

    private int rand;
    private int randPosition;
    [SerializeField] private float StartTimeBtwSpawns;
    private float timeBtwSpawns;

    private bool _isActive;

    void Start()
    {
        timeBtwSpawns = StartTimeBtwSpawns;
    }

    void Update()
    {   
        if(_isActive == true)
        {
            if (timeBtwSpawns <= 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    rand = Random.Range(0, cubes.Length);
                    randPosition = Random.Range(0, spawnpos.Length);
                    Instantiate(cubes[rand], spawnpos[randPosition].transform.position, Quaternion.identity);
                    timeBtwSpawns = StartTimeBtwSpawns;
                    i++;
                }
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out PlayerMover playerMover))
        {
            _isActive = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMover playerMover))
        {
            _isActive = false;
        }
    }
}
