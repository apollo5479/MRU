using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    Transform target;
    public Rigidbody rb;
    public float speed = 5f;
    Vector3 targetDirection;
    public float whenDie = 2f;
    private MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
        GetComponent<BulletBehaviour>().target = GameObject.FindWithTag("Player").transform;
        targetDirection = target.position - transform.position;
        Destroy(gameObject, whenDie);
        Invoke("goVisible", 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
        float singleStep = speed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
        transform.position += transform.forward * Time.deltaTime;
    }

    void goVisible() {
        meshRenderer.enabled = true;
    }
}
