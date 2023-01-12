using UnityEngine;
using UnityEngine.InputSystem;

public class Player1 : PlayerBase, InputPlayer1.IPlayerActions
{
    private InputPlayer1 _inputP1 = null;

    public void OnAttack(InputAction.CallbackContext context)
    {
        _input.attack = context.performed;
    }

    public void OnAvoid(InputAction.CallbackContext context)
    {
        _input.avoid = context.performed;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _input.move = context.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        _inputP1.Enable();
    }

    private void OnDisable()
    {
        _inputP1.Disable();
    }

    private void OnDestroy()
    {
        _inputP1.Dispose();
    }

    private void Awake()
    {
        _inputP1 = new InputPlayer1();
        _inputP1.Player.SetCallbacks(this);
    }
}
