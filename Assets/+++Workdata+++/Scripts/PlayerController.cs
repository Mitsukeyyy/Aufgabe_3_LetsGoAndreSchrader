using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 6f; // declaring float for the movement speed

    [SerializeField] private float direction; // used to set the player direction
    
    [SerializeField] private float jumpHeight = 4f; // used to access jumps and declare a height 

    private int countdown = 0;
    
    private Rigidbody2D rb; // declared to use the Rigidbody in the script 

    [SerializeField] Transform transformGroundCheck; // makes it only possible to jump when the player is on a ground platform
    private LayerMask layerGround; // to give a Ground layer to objects 

    [SerializeField] private UI_Manager uimanager; 
    [SerializeField] private GameManager gameManager; //used to use other scripts in this script 

    public bool canMove = true; //used to disable movement after a death or win 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Countdown());
        rb = GetComponent<Rigidbody2D>(); // taking the RigidBody2D values on the gameObject 
        layerGround = LayerMask.GetMask("Ground"); //declaring the layerMask to be the Ground layer 
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove) //only making it possible to move when the player canMove = true
        {
            direction = 0f; //sets default direction to 0 meaning the player cant move 
            
            if (Keyboard.current.aKey.isPressed)
            {
                direction = -1;
            }

            if (Keyboard.current.dKey.isPressed)
            {
                direction = 1; 
            }
            // declared a and d for the movement, -1 meaning going backwards while 1 means forward 

            if (Keyboard.current.spaceKey.isPressed)
            {
                Jump();
            }
            //added the Jump function to the movement on the space bar 
            rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y); //giving the Rigidbody(rb) a linear movement while direction * speed is the movement and y = 0 
        }
    }
    void Jump() //function to make jumping work 
    {
        if (Physics2D.OverlapCircle(transformGroundCheck.position, 0.1f, layerGround)) 
            rb.linearVelocity = new Vector2(0, jumpHeight); 
    }
    // if the GroundCheck GameObject is within a radius to the layerGround y gets set to jumpHeight     
    private void OnTriggerEnter2D(Collider2D other) //used for any collidable object 
    {
        if (other.CompareTag("coin")) 
        {
            Destroy(other.gameObject); //if the collectable was a coin, it gets destroyed and the counter adds up 
             gameManager.IncreaseCounter(); // increases Coincounter and displays it on a Textfield
            
        }else if (other.CompareTag("obstacle")) 
        {
            rb.linearVelocity = Vector2.zero;
            canMove = false; //if the player collides with an obstacle the game counts as lost. 
            uimanager.ShowLostPanel();
            
        }
    }
    IEnumerator Countdown() //creates a Coroutine for a Countdown before the game starts 
    {
        for (countdown = 0; countdown < 3; countdown++)
        {
            canMove = false;
            yield return new WaitForSeconds(1f); //counts the variable countdown up to three, then lets the player move. 
        }
        canMove = true;
    }
    

    
}
