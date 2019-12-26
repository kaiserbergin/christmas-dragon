﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragonController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1.0f;

    [SerializeField]
    private GameObject _dragon;

    [SerializeField]
    public Border _border;

    private Animator _animator;
    private Vector2 _movementInput;
    private bool _fireInput;

    // Start is called before the first frame update
    void Start()
    {
        if (_dragon == null) throw new MissingComponentException("Dragon component not assigned to DragonController.cs");
        if (_border == null) throw new MissingComponentException("Border script must be assigned to DragonController.cs");

        _animator = _dragon.gameObject.GetComponent<Animator>();
        _animator.SetBool("Fly Idle", true);
        _animator.SetBool("Fly Forward", true);
    }

    // Update is called once per frame
    void Update()
    {
        float xAxisInput = _movementInput.x;
        float yAxisInput = _movementInput.y;

        if (xAxisInput != 0 || yAxisInput != 0)
        {
            // Y axis for a Vector2 translates to Z axis for Vector3
            this.transform.position = new Vector3(UpdateXAxisPosition(xAxisInput), this.transform.position.y, UpdateZAxisPosition(yAxisInput));
        }
    }

    public void Move(InputAction.CallbackContext context) => _movementInput = context.ReadValue<Vector2>();

    public void Fire(InputAction.CallbackContext context) => _fireInput = context.performed;

    private float UpdateXAxisPosition(float xAxisInput)
    {
        return Mathf.Clamp(this.transform.position.x + xAxisInput * _speed * Time.deltaTime, _border.xMin, _border.xMax);
    }

    private float UpdateZAxisPosition(float yAxisInput)
    {
        return Mathf.Clamp(this.transform.position.z + yAxisInput * _speed * Time.deltaTime, _border.zMin, _border.zMax);
    }
}
