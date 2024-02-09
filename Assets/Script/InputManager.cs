using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    CharacterControl characterControl;
    PlayerLocomotion locomotion;
    AnimatorManager animatorManager;

    public Vector2 movementInput;
    public Vector2 cameraInput;

    public float cameraInputX;
    public float cameraInputY;

    public float moveAmount;
    public float verticalInput;
    public float horizontalInput;

    public bool b_Input;

    private void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
        locomotion = GetComponent<PlayerLocomotion>();
    }

    private void OnEnable()
    {
        if (characterControl == null)
        {
            characterControl = new CharacterControl();

            characterControl.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            characterControl.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();

            characterControl.PlayerAction.B.performed += i => b_Input = true;
            characterControl.PlayerAction.B.canceled += i => b_Input = false;
        }

        characterControl.Enable();
    }

    private void OnDisable()
    {
        characterControl.Disable();
    }

    public void HandleAllInput()
    {
        HandleMovementInput();
        HandleSprintingInput();
        //HandleJumpingInput
        //HandleActionInput
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        cameraInputY = cameraInput.y;
        cameraInputX = cameraInput.x;

        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorValues(0, moveAmount, locomotion.isSprinting);
    }

    private void HandleSprintingInput()
    {
        if (b_Input && moveAmount > 0.5f)
        {
            locomotion.isSprinting = true;
        }
        else
        {
            locomotion.isSprinting = false;
        }
    }
}
