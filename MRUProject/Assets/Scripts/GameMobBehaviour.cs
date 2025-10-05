using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMobBehaviour : MonoBehaviour
{
    Transform target;
    public Rigidbody rb;
    public Animator animator;

    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    public bool isAttacking = false;
    public bool isMoving = true;
    public float attackRange;
    public float attackTimer = 0;
    public float attackCooldown;
    public float distance;
    //public Transform spawnPosition;
    public GameObject magicBullet;
    public Vector3 spawnOffset = new Vector3(0f, 0.336f, 0.5f);

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        GetComponent<GameMobBehaviour>().target = GameObject.FindWithTag("Player").transform;
        if (gameObject.tag == "Tank")
        {
            attackRange = 1f;
            attackCooldown = 3f;
        }
        else if (gameObject.tag == "Mage")
        {
            attackRange = 5f;
            attackCooldown = 2f;
        }
        //spawnPosition = transform.Find("bulletSpawn");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        distance = Vector3.Distance(rb.position, target.position);
        if (attackTimer > 0)
        {
            attackTimer -= Time.fixedDeltaTime;
        }

        // If close enough and not on cooldown
        if (distance <= attackRange && !isAttacking && attackTimer <= 0f)
        {
            
            StartCoroutine(Attack());
        }

        if (isMoving && !isAttacking)
        {
            MoveTowardTarget();
        }
    }
    void MoveTowardTarget()
    {
        Vector3 direction = target.position - rb.position;
        direction.y = 0f;

        if (direction.magnitude > 0.1f)
        {

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            targetRotation *= Quaternion.Euler(0, -180, 0);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime));
            Vector3 newPos = Vector3.MoveTowards(rb.position, target.position, moveSpeed * Time.fixedDeltaTime);

            if (distance >= attackRange)
            {
                rb.MovePosition(newPos);
            }
        }
    }
    private System.Collections.IEnumerator Attack()
    {
        isAttacking = true;
        isMoving = false;
        attackTimer = attackCooldown;

        animator.SetTrigger("AttackTrigger");
        
        yield return new WaitForSeconds(1f);

        isAttacking = false;
        isMoving = true;
    }

    public void spawnMissile() {
        if (gameObject.tag == "Mage")
        {
            Instantiate(magicBullet, gameObject.transform.position, gameObject.transform.rotation); // + spawnOffset
        }
    }


}
