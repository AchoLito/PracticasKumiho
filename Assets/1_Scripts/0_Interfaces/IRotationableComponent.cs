using UnityEngine;

public interface IRotationableComponent
{
    float rotateSpeed {  get; set; }

    void Rotation();
}
