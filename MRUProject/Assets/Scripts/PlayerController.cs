using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerData playerData;
    private Transform playerTransform;
    private Rigidbody rb;

    private Vector3 inputVector;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
{
    // Read input in Update()
    inputVector = Vector3.zero;
    if (Input.GetKey("a")) inputVector.x -= 1;
    if (Input.GetKey("d")) inputVector.x += 1;
    if (Input.GetKey("w")) inputVector.z += 1;
    if (Input.GetKey("s")) inputVector.z -= 1;

    inputVector.Normalize(); // prevent diagonal speed boost
}

void FixedUpdate()
{
    // Move in FixedUpdate using physics
    Vector3 move = inputVector * playerData.speed * Time.fixedDeltaTime;
    rb.MovePosition(rb.position + move);
}
}
