using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    IMoveableComponent _playerMovement;

    void Start()
    {
        _playerMovement = GetComponent<IMoveableComponent>();
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
        Debug.Log("Estoy cogiendo este valor: " + context.ReadValue<Vector2>());
    }
}
