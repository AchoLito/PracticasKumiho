using System.Collections;
using UnityEngine;

public class PlayerJumpComponent : MonoBehaviour, IJumpComponent
{
    public float gravityScale { get; set; }
    public float maxJumpHeight { get; set; }
    public float maxJumpTime { get; set; }
    public float jumpForce { get; set; }
    public bool isJumping { get; set; }
    public bool isGrounded { get; set; }
    public bool isFalling { get; set; }
    public Rigidbody rb { get; set; }

    float _jumpDuration;

    LayerMask layerMask;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isJumping = false;
        isGrounded = true;
        isFalling = false;
        jumpForce = 5f;

        gravityScale = 1f;

        maxJumpTime = 0.3f;

        rb = GetComponent<Rigidbody>();

        layerMask = LayerMask.GetMask("Floor");
    }

    public void Jump()
    {
        float timeDuration =  _jumpDuration;
        Debug.Log("TimeDuration: " + timeDuration + " MaxDuration: " + maxJumpTime);
        if (timeDuration >= maxJumpTime) { SetGrounded(); return; }
        isJumping=true;
        _jumpDuration += Time.deltaTime;
        rb.linearVelocity = jumpForce * Vector3.up;     
    }

    public bool SetGrounded()
    {
        StartCoroutine(CheckGrounded());
        isFalling = true;
        return true;
    }

    bool IsItGrounded()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f, layerMask))
        {
            Debug.DrawRay(transform.position, Vector3.down * hit.distance, Color.red);
            isGrounded = true;
            isJumping = false;
            isFalling = false;
            _jumpDuration = 0;
            return true;
        }

        Debug.DrawRay(transform.position, Vector3.down * hit.distance, Color.red);
        return false;
    }

    IEnumerator CheckGrounded()
    {
        while(!IsItGrounded())
        {
            Debug.Log("Estoy checkeando si estoy en el suelo");
            yield return null;
        }
    }
}
