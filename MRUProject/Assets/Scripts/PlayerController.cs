using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerData playerData;
    private Transform playerTransform;
    private Rigidbody rb;
    //public bool isMoving = true;
    private Animator animator;
    public float moveSpeed = 5f;
    private Vector3 moveDirection;
    private Vector3 moveInput;
    public MouseTracker mouseTracker;

    public leftClick lClick;
    public GameObject HitboxField;

    private Vector3 inputVector;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        mouseTracker = GetComponent<MouseTracker>();
        GameObject lclicky = GameObject.Find("AttackObject");
        lClick = lclicky.GetComponent<leftClick>();
        animator.SetBool("isMoving", true);
        //rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
{       
        if (Input.GetMouseButtonDown(0)) {
            //animator.enabled;
            //animator.SetInteger("whichAttack", 4);
            //animator.SetTrigger("Auto"); 
            //Debug.Log("Triggering Auto");
            animator.Play("Animation_NormalAttack");
            lClick.goVisible();
            Instantiate(HitboxField, playerTransform.position, playerTransform.rotation);
        }
        /*
        animator.SetBool("isMoving", false);
        inputVector = Vector3.zero;
        if (Input.GetKey("a")) {
            Debug.Log("Pressing a");
            inputVector.x -= 1;
            animator.SetBool("isMoving", true);
        }
        if (Input.GetKey("d")) {
            Debug.Log("Pressing d");
            inputVector.x += 1;
            animator.SetBool("isMoving", true);
        }
        if (Input.GetKey("w")) {
            Debug.Log("Pressing w");
            inputVector.z += 1;
            animator.SetBool("isMoving", true);
        }
        if (Input.GetKey("s")) {
            Debug.Log("Pressing s");
            inputVector.z -= 1;
            animator.SetBool("isMoving", true);
        }
        inputVector.Normalize(); // prevent diagonal speed boost*/
        
        

        float moveX = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        float moveZ = Input.GetAxisRaw("Vertical");   // W/S or Up/Down
        moveDirection = new Vector3(moveX, 0f, moveZ).normalized;

    }

void FixedUpdate()
{
        // Move in FixedUpdate using physics
        //Vector3 move = inputVector * playerData.speed * Time.fixedDeltaTime;
        //rb.MovePosition(rb.position + move);


        if (moveDirection != Vector3.zero)
        {
            
            Vector3 newPosition = transform.position + moveDirection * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(newPosition);
        }
        else {
            animator.SetBool("isMoving", false);
        }
    }

    void playAnim() {
    
    }
}
