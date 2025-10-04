using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerData playerData;
    private Transform playerTransform;
    private Rigidbody rb;

    private Vector3 moveVector;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FixedUpdate()
    {
        Vector3 moveVector = Vector3.zero;

        if (Input.GetKey("a")) moveVector.x -= 1;
        if (Input.GetKey("d")) moveVector.x += 1;
        if (Input.GetKey("w")) moveVector.z += 1;
        if (Input.GetKey("s")) moveVector.z -= 1;

        moveVector.Normalize();
        rb.MovePosition(rb.position + moveVector * playerData.speed * Time.fixedDeltaTime);
        playerTransform.rotation = Quaternion.identity;
    }
}
