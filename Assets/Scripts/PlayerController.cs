using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float jumpHeight = 2.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private float maxVerticalAngle = 80f;

    [SerializeField] private GameObject objectives;

    public float sensitivity = 300.0f;

    [SerializeField] private Camera playerCamera;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private Vector2 movementInput = Vector2.zero;
    private bool jumped = false;

    private Vector2 mouseInput = Vector2.zero;
    private float currentYrot = 180f;
    private float currentXrot;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        Time.timeScale = 0f;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        // Disable this comment if I want the jump mechanic in the game
        //jumped = context.action.triggered;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseInput = context.ReadValue<Vector2>();
    }

    public void OnObjective(InputAction.CallbackContext context)
    {
        if(objectives.activeInHierarchy)
        {
            objectives.SetActive(false);
        }
        else
        {
            objectives.SetActive(true);
        }
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
        move.Normalize();
        move = transform.rotation * move;
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (jumped && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        currentYrot += mouseInput.x * sensitivity * Time.deltaTime;
        currentXrot += -mouseInput.y * sensitivity * Time.deltaTime;

        // Lock camera angle so you can't look upside down
        currentXrot = Mathf.Clamp(currentXrot, -maxVerticalAngle, maxVerticalAngle);

        transform.rotation = Quaternion.Euler(0, currentYrot, 0);
        playerCamera.transform.localRotation = Quaternion.Euler(currentXrot, 0, 0);
    }
}