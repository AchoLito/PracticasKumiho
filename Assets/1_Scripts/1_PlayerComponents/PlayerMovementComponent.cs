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
    public float distance { get; set; }

    [SerializeField] float _rotateSpeed = 1f;

    private void Awake()
    {
        distance = 1f;
    }

    public void Move()
    {
        Debug.Log("Direccion 1: " + direction);

        RaycastHit hit;
        
        Vector3 movement = IsometricVector.TransformToIsometricCoords(new Vector3(direction.x, 0, direction.y));

        if (Physics.Raycast(transform.position, movement, out hit, distance, LayerMask.GetMask("Wall", "Floor")))
        {
            return;
        }
        Debug.DrawRay(transform.position, Vector3.forward * hit.distance, Color.red, 100);

        transform.Translate(Time.deltaTime * speed * movement, Space.World);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(movement, Vector3.up), Time.deltaTime * _rotateSpeed);
    }
}
