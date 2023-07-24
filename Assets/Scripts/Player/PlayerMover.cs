using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Cinemachine.AxisState;
using DG.Tweening;
using System;
using static UnityEngine.EventSystems.EventTrigger;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 500;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private bool _isGrounded = true;
    [SerializeField] private float _jumpForce = 50f;
    [SerializeField] private float _force_repulsion = 2f;
    [Header("Model")]
    [SerializeField] private Transform _model;
    [SerializeField] private Vector3 _direction = new Vector3(0f, 1f, 0f);
    [SerializeField] private float _modelRotationCoeff;
    [SerializeField] private Transform _rayJump;

    [Header("Partycle")]
    [SerializeField] private ParticleSystem IceFloorTrail;
    [SerializeField] private ParticleSystem WindlinesSpeedy;

    private Rigidbody _rigidbody;
    private PlayerAnimator _animator;
    [SerializeField] private bool _isBall = false;
    public bool IsBall => _isBall;

    [SerializeField] private Transform _cameraTransform;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = FindObjectOfType<PlayerAnimator>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _rigidbody.AddForce(transform.forward * vertical * _speed * Time.deltaTime);

        transform.Rotate((transform.up * horizontal) * _rotationSpeed * Time.deltaTime);

        if (_isBall == true)
        {
            IceFloorTrail.Play();
            WindlinesSpeedy.Play();
            _model.Rotate(_rigidbody.velocity.magnitude * _direction * _modelRotationCoeff * Time.deltaTime);
        }

        if (_isBall == false)
        {
            IceFloorTrail.Stop();
            WindlinesSpeedy.Stop();
            _model.DOLocalRotate(new Vector3(0, 0, -horizontal * 25), 1);
            _model.DOLocalRotate(new Vector3(vertical * 25, 0, 0), 1);
        }
    }

    private void Update()
    {
        if (_isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce);
            _isGrounded = false;
        }
    }

    public void TakeSpeedBooster(float power)
    {
        _isBall = true;

        _rigidbody.AddForce(transform.forward * power * _speed * Time.deltaTime);

        StartCoroutine(SpeedBoosterTimer());

        _animator.CloseBall();
    }

    private IEnumerator SpeedBoosterTimer(float useTime = 5f)
    {
        yield return new WaitForSeconds(useTime);

        _animator.OpenBall();
        _isBall = false;
        //_speed /= 2;

        _model.DOLocalRotate(Vector3.zero, 0.5f);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void OnCollisionStay(Collision collision)
    {

        Ray ray = new Ray(_rayJump.transform.position, Vector3.down);
        RaycastHit rh;
        if (Physics.Raycast(ray, out rh, 0.5f))
        {
            _isGrounded = true;
        }

        if (collision.gameObject.TryGetComponent(out PlatformBounce platformBounce))
        {
            _rigidbody.AddForce(Vector3.up * platformBounce.Power, ForceMode.Impulse);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Enemy enemyDealsDamage) && _isBall == true)
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            Vector3 dir = (gameObject.transform.position - obstacle.transform.position);
            _rigidbody.AddForce(dir * 8f, ForceMode.Impulse);
        }


    }

    private void OnCollisionExit(Collision collision)
    {
        _isGrounded = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out SpeedAmplifier speedAmplifiers))
        {
            TakeSpeedBooster(speedAmplifiers.Power);
        }
    }

}

