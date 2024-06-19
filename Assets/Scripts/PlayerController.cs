using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _turnSpeed = 500;
    [SerializeField] private float _jumpPower = 5;
    private Vector3 _input;
    private bool _isJumping = false;

    [SerializeField] private SkinnedMeshRenderer _childMesh;
    [SerializeField] private SkinnedMeshRenderer _defaultMeshField;
    [SerializeField] private SkinnedMeshRenderer _skateMeshField;

    // Animation
    [SerializeField] private Animator _animator;

    void GatherInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            _speed = 15;
            _animator.SetFloat("Movement", 20);
            SetMeshRenderer(_skateMeshField);
        }
        else
        {
            _speed = 5;
            _animator.SetFloat("Movement", 10);
            SetMeshRenderer(_defaultMeshField);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !_isJumping)
        {
            Jump();
        }
    }

    void Update()
    {
        GatherInput();
        Look();

        if (_input == Vector3.zero)
        {
            _animator.SetFloat("Movement", 0);
            _speed = 5;
            SetMeshRenderer(_defaultMeshField);
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void Look()
    {
        if (_input != Vector3.zero)
        {
            var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
            var skewedInput = matrix.MultiplyPoint3x4(_input);

            var relative = (transform.position + skewedInput) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed * Time.deltaTime);
        }
    }

    void Move()
    {
        _rb.MovePosition(transform.position + (transform.forward * _input.magnitude) * _speed * Time.deltaTime);

        _animator.SetFloat("Movement", 10);
    }

    void SetMeshRenderer(SkinnedMeshRenderer meshRenderer)
    {
        _childMesh.sharedMesh = meshRenderer.sharedMesh;
        _childMesh.materials = meshRenderer.sharedMaterials;
    }

    void Jump()
    {
        _isJumping = true;
        _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);

        StartCoroutine(EndJump());
    }

    IEnumerator EndJump()
    {
        yield return new WaitForSeconds(1f);

        _isJumping = false;
    }
}