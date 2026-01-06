using UnityEngine;

public interface IMoveableComponent
{
    Vector2 direction {  get; set; }
    float distance { get; set; }
    float speed { get; set; }
    void Move();
}
