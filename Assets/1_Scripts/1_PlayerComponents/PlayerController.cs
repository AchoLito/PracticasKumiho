using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    IMoveableComponent _playerMovement;
    ICanInteractComponent _playerInteract;
    IJumpComponent _playerJump;

    void Start()
    {
        _playerMovement = GetComponent<IMoveableComponent>();
        _playerInteract = GetComponent<ICanInteractComponent>();
        _playerJump = GetComponent<IJumpComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerMovement.direction != Vector2.zero)
            _playerMovement.Move();
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

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
            _playerJump.Jump(Time.time);
    }
}
