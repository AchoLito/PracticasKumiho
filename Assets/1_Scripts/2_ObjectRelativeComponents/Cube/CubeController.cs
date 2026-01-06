using System;
using UnityEngine;

public class CubeController : InteractuableComponent
{
    bool _isFloor = true;

    Action _doTheThing;

    CubeDescend _descend = new CubeDescend();
    CubeElevate _elevate= new CubeElevate();

    [SerializeField] public InteractuableEnums.Colors color;

    Rigidbody rb;

    IMoveableComponent _playerMovement;

    public override void ThingIDo()
    {
        _doTheThing?.Invoke();

        if (_isFloor)
        {
            _doTheThing = Descend;
            _isFloor = false;
        }
        else
        {
            _doTheThing = Elevate;
            _isFloor = true;
        }          
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _doTheThing = Elevate;

        _playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<IMoveableComponent>();
    }

    private void Update()
    {
        if (!_isFloor)
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    public void Elevate()
    {
        rb.isKinematic = true;
        _elevate.ThingIDo(transform);
        gameObject.layer = LayerMask.NameToLayer("Player");
        _playerMovement.distance = 2.5f;
    }

    public void Descend()
    {
        rb.isKinematic = false;
        _descend.ThingIDo(transform);
        gameObject.layer = LayerMask.NameToLayer("Default");
        _playerMovement.distance = 1f;
    }
}
