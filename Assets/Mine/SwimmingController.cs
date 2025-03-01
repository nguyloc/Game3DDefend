using UnityEngine;
using Invector.vCharacterController;

public class SwimmingController : MonoBehaviour
{
    public CharacterController characterController;
    public vThirdPersonController thirdPersonController;
    public float swimSpeed = 3f;
    public float swimUpSpeed = 2f;

    private bool isSwimming = false;
    private Vector3 moveDirection;

    void Start()
    {
        thirdPersonController = GetComponent<vThirdPersonController>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (isSwimming)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            moveDirection = new Vector3(horizontal, 0, vertical).normalized * swimSpeed;

            if (Input.GetKey(KeyCode.Space)) // Nhấn Space để bơi lên
            {
                moveDirection.y = swimUpSpeed;
            }
            else
            {
                moveDirection.y = -0.5f; // Giảm dần để mô phỏng độ chìm
            }

            characterController.Move(moveDirection * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water")) // Object nước phải có tag "Water"
        {
            isSwimming = true;
            thirdPersonController.moveSpeed = swimSpeed; // Giảm tốc độ bơi
            thirdPersonController.moveSpeed = swimSpeed * 1.2f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isSwimming = false;
            thirdPersonController.moveSpeed = 4f; // Reset tốc độ di chuyển
            thirdPersonController.moveSpeed = 6f;
        }
    }
}

