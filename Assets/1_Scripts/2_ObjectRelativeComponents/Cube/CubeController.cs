using System;
using UnityEngine;

public class CubeController : InteractuableComponent
{
    bool isFloor = true;

    Action doTheThing;

    CubeDescend descend = new CubeDescend();
    CubeElevate elevate= new CubeElevate();

    Rigidbody rb;

    public override void ThingIDo()
    {
        doTheThing?.Invoke();

        if (isFloor)
        {
            doTheThing = Descend;
            rb.useGravity = false;
            isFloor = false;
        }
        else
        {
            doTheThing = Elevate;
            rb.useGravity = true;
            isFloor = true;
        }          
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        doTheThing = Elevate;
    }

    public void Elevate()
    {
        elevate.ThingIDo(transform);
    }

    public void Descend()
    {
        descend.ThingIDo(transform);
    }
}
