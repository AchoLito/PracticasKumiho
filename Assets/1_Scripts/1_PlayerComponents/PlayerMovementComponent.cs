using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovementComponent : MonoBehaviour, IMoveableComponent
{
    public Vector2 direction { get; set; }
    [SerializeField] float _speed = 1f;
    public float speed 
    { 
        get => _speed;
        set => _speed = value;
    }

    [SerializeField] float _rotateSpeed = 1f;

    public void Move()
    {
        Debug.Log("Direccion 1: " + direction);

        Vector3 movement = IsometricVector.TransformToIsometricCoords(new Vector3(direction.x, 0, direction.y));

        transform.Translate(Time.deltaTime * speed * movement, Space.World);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(movement, Vector3.up), Time.deltaTime * _rotateSpeed);
    }
}
