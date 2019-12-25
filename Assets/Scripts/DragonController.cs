using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragonController : MonoBehaviour
{
    private Animator _animator;

    private Vector2 movementInput;
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
        float horizontalInput = movementInput.x;
        float verticalInput = movementInput.y;
    }

    public void Move(InputAction.CallbackContext context) => movementInput = context.ReadValue<Vector2>();
}
