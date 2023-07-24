using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelMover : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;

    private bool _isFreeMove = false;
    private Transform _player;

    public void MoveInDirection(Vector3 direction)
    {
        if (_isFreeMove == true)
        {
            transform.position = _player.position + _offset;
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    public void UseUnparentMove(Transform parent)
    {
        _player = parent;
        _isFreeMove = false;
        transform.SetParent(parent);
    }

    public void UseParentMove(Transform parent)
    {
        _player = parent;
        _isFreeMove = true;
        transform.SetParent(parent);
    }
}
