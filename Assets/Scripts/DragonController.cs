using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragonController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1.0f;

    private Animator _animator;
    private Vector2 _movementInput;
    private bool _fireInput;

    // Start is called before the first frame update
    void Start()
    {
        _animator = this.gameObject.GetComponent<Animator>();
        foreach (var param in _animator.parameters)
        {
            Debug.Log(param.name + " :: " + param.type + " :: " + param.nameHash);
        }
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
            Debug.Log("horizontalInput: " + xAxisInput);
            Debug.Log("verticalInput: " + yAxisInput);

            // Y axis for a Vector2 translates to Z axis for Vector3
            this.transform.position += new Vector3(xAxisInput, 0f, yAxisInput) * _speed * Time.deltaTime;
        }
    }

    public void Move(InputAction.CallbackContext context) => _movementInput = context.ReadValue<Vector2>();

    public void Fire(InputAction.CallbackContext context) => _fireInput = context.performed;
}
