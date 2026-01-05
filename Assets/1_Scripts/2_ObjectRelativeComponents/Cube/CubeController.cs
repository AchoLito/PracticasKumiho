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
    }

    public void Elevate()
    {
        rb.useGravity = false;
        _elevate.ThingIDo(transform);
    }

    public void Descend()
    {
        rb.useGravity = true;
        _descend.ThingIDo(transform);
    }
}
