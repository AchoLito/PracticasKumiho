using UnityEngine;

public interface IJumpComponent
{
    float gravityScale {  get; set; }
    float maxJumpHeight { get; set; }
    float maxJumpTime { get; set; }
    float jumpForce { get; set; }

    bool isJumping {  get; set; }
    bool isGrounded { get; set; }

    Rigidbody rb {  get; set; }

    void Jump(float duration);

    bool SetGrounded();
}
