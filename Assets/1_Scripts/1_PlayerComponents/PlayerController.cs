using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    IMoveableComponent _playerMovement;
    ICanInteractComponent _playerInteract;
    IJumpComponent _playerJump;

    [SerializeField]InputAction _jump;

    void Start()
    {
        _playerMovement = GetComponent<IMoveableComponent>();
        _playerInteract = GetComponent<ICanInteractComponent>();
        _playerJump = GetComponent<IJumpComponent>();

        _jump = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerMovement.direction != Vector2.zero)
            _playerMovement.Move();

        if(_jump.IsPressed() && !_playerJump.isFalling)
        {
            _playerJump.Jump();
        }
        else if(_playerJump.isJumping)
        {
            _playerJump.SetGrounded();
        }
    }

    public void UpdateDirection(InputAction.CallbackContext context)
    {
        _playerMovement.direction = context.ReadValue<Vector2>();
    }

    public void Interact(InputAction.CallbackContext context)
    {
        Debug.Log("Boton: " + context.ReadValueAsButton());
        if(context.ReadValueAsButton())
            _playerInteract.interactFunction?.Invoke();
    }
}
