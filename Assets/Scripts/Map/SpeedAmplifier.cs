using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedAmplifier : MonoBehaviour
{
    [SerializeField] private float _power = 20f;

    public float Power => _power;
}
