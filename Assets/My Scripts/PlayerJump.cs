
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : NetworkBehaviour
{
    public float jumpForce = 5f;
    private Rigidbody rb;
    private bool isJumping;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        isJumping = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
          //  Debug.Log("Jumping...");
          isJumping=true;
            Jump();
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        // Debug.Log("Jump Force Applied!");
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }
}
