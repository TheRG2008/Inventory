using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private int _sizeInventory;
    [SerializeField] private bool groundedPlayer;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float _sensitivity = 150f;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private float _yRotaye;
    private IInventory _inventory;
    public IInventory Inventory 
        => _inventory;
    private void Awake()
    {
        _inventory = new Inventory(_sizeInventory);
    }
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = transform.TransformDirection(move);
        controller.Move(move * Time.deltaTime * playerSpeed);

       


        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        MouseLook();

    }
    void MouseLook()
    {
        _yRotaye = Input.GetAxis("Mouse X");
        transform.Rotate(0, _yRotaye * _sensitivity * Time.deltaTime, 0);
    }

    
}
