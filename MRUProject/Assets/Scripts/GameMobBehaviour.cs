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
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float distance = Vector3.Distance(rb.position, target.position);
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
        /*if (isAttacking) {
            Vector3 direction = target.position - transform.position;
            direction.y = 0f;

            if (direction.magnitude > 0.1f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime));

                if ((Vector3.Distance(transform.position, target.position) < 10f) && gameObject.tag == "Mage")
                {
                    // initiate attack
                    StartCoroutine(Attack());
                    //attack(1);
                    isAttacking = true;
                    return;
                }
                if ((Vector3.Distance(transform.position, target.position) < 3f) && gameObject.tag == "Tank")
                {
                    // initiate attack
                    StartCoroutine(Attack());
                    //attack(2);
                    isAttacking = true;
                    return;
                }
                Vector3 newPosition = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.fixedDeltaTime);
                rb.MovePosition(newPosition);
                isMoving = true;
            }
        }*/
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
            rb.MovePosition(newPos);
            /*if (distance >= attackRange)
            {
                
            }*/
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
    void attack(int who)
    {
        /*if (who == 1) { // mage
            animator.SetTrigger("AttackTrigger")
            yield return new WaitForSeconds(1f);
        } else if (who == 2) { //tank
            animator.SetTrigger("AttackTrigger")
            yield return new WaitForSeconds(1f);
        }*/
    }

}
