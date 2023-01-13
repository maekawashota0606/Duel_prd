using UnityEngine;
using UnityEngine.InputSystem;

public class Player : PlayerBase
{
    private PlayerInput _playerInput = null;

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.action.name != "Attack")
            return;
        _input.attack = context.performed;
    }

    public void OnAvoid(InputAction.CallbackContext context)
    {
        if (context.action.name != "Avoid")
            return;

        Debug.Log("avoid");
        _input.avoid = context.performed;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.action.name != "Move")
            return;
        _input.move = context.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerInput.onActionTriggered += OnMove;
        _playerInput.onActionTriggered += OnAttack;
        _playerInput.onActionTriggered += OnAvoid;
    }

    private void OnDisable()
    {
        // デリゲート削除などを行う
        //_playerInput.onActionTriggered -= OnMove;
    }
}
