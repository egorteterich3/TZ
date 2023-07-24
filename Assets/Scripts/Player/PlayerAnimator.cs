using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void OpenBall()
    {
        _animator.SetBool("Opening", false);
    }

    public void CloseBall()
    {
        _animator.SetBool("Opening", true);
    }
}
