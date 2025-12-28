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
    public Rigidbody rb { get; set; }

    float _jumpDuration;

    LayerMask layerMask;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isJumping = false;
        isGrounded = false;
        jumpForce = 5f;
        maxJumpHeight = 5f;

        gravityScale = 1f;

        maxJumpTime = Mathf.Sqrt(2*maxJumpHeight/(-Physics.gravity.y)) - (2*jumpForce/Physics.gravity.y);

        rb = GetComponent<Rigidbody>();

        layerMask = LayerMask.GetMask("Floor");
    }

    public void Jump(float duration)
    {
        if (!isJumping)
             _jumpDuration = duration;

        float timeDuration = duration - _jumpDuration;
        Debug.Log("TimeDuration: " + timeDuration + " MaxDuration: " + maxJumpTime);
        if (timeDuration >= maxJumpTime) return;
        isJumping=true;
        float jumpHeight = Mathf.Min(duration/ maxJumpTime*maxJumpHeight, maxJumpHeight);

        rb.AddForce(new Vector2(0f, jumpHeight/maxJumpHeight*jumpForce*gravityScale),ForceMode.Impulse);

        StartCoroutine(CheckGrounded());
    }

    public bool SetGrounded()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, Vector3.down, out hit, 1f, layerMask))
        {
            Debug.DrawRay(transform.position, Vector3.down * hit.distance, Color.red);
            isGrounded=true;
            isJumping=false;
            return true;
        }

        Debug.DrawRay(transform.position, Vector3.down * hit.distance, Color.red);
        return false;
    }

    IEnumerator CheckGrounded()
    {
        while(!SetGrounded())
        {
            Debug.Log("Estoy checkeando si estoy en el suelo");
            yield return null;
        }
    }
}
