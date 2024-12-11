using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2D : MonoBehaviour
{
    //Referencias privadas generales.
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] PlayerInput playerInput;
    Vector2 moveInput; //Variables para referencar el input de los controladores

    [Header("Movement Parameters")]
    public float speed;

    [Header("Jump parameters")]
    public float jumpForce;
   [SerializeField] private bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
      //Praa autpreferirse: nombre de variabl e= GetComponent<tipo de variable>()
      playerRb = GetComponent<Rigidbody2D>();
      playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Movement();
    }
    void Movement()
    {
        playerRb.velocity = new Vector3(moveInput.x * speed, playerRb.velocity.y, 0);
    }

    #region Input Methods
    // metodos que permiten leer el inpt de New Input System
    //crearemos un metodo por cada accion

    public void HandLeMovemnet(InputAction.CallbackContext context)
    { 
    //las acciones de tipo VALUE deben almacenarse = RealValue
    moveInput = context.ReadValue<Vector2>();
    }
    

    public void HandLeJump(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }

    }



    #endregion





}
