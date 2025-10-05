using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour
{
    public int health = 5;
    public ParticleSystem bloodParticle;
    //public Animator animator;
    //public Damage damageScript;
    //public AnimatorStateInfo stateInfo;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Damagers")) {
            takeDamage(1);
            TriggerBloodEffect(gameObject.transform.position);
        }

        /*AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (other.gameObject.CompareTag("Player") && stateInfo.IsName("Attack"))
        {
            TriggerBloodEffect(gameObject.transform.position);
            damageScript.takeDamage(1);
        }*/

            /*if (other.gameObject.CompareTag("Tank") || other.gameObject.CompareTag("Mage")) {
                TriggerBloodEffect(gameObject.transform.position);
            }




            if (other.gameObject.CompareTag("Mage") || other.gameObject.CompareTag("Tank"))
            {
                AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

                if (stateInfo.IsName("Attack"))
                {
                    Debug.Log("Player is vulnerable during 'Hurt' animation. Taking damage.");
                    takeDamage(1);
                }
            }

            /*Animator animator = other.gameObject.GetComponent<Animator>();
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            Debug.Log(stateInfo.ToString());
            if ((gameObject.tag == "Player")) {
                Debug.Log(" Player had a collision");
                if (other.gameObject.CompareTag("Mage") && stateInfo.IsName("Attack"))
                {
                    Debug.Log("You got hit by the mage");
                    takeDamage(1);
                }
                if (other.gameObject.CompareTag("Tank") && stateInfo.IsName("Attack"))
                {
                    Debug.Log("You got hit by the tank");
                    takeDamage(3);
                }
            } else if ((gameObject.tag == "Mage") || (gameObject.tag == "Tank")) {
                Debug.Log("I got hit by a player");
                if (stateInfo.IsName("Stab") && other.gameObject.CompareTag("Player"))
                {
                    takeDamage(2);
                }
                if (stateInfo.IsName("AoE") && other.gameObject.CompareTag("Player"))
                {
                    takeDamage(4);
                }
                if (stateInfo.IsName("Slash") && other.gameObject.CompareTag("Player"))
                {
                    takeDamage(1);
                }
            }

            /*if (other.gameObject.CompareTag("Player") && ())
            {

            }*/
    }

    //attach this script to enemies
    //if my animator state is attack and colliding with player = damage

    // Start is called before the first frame update
    void Start()
    {

        //AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0); // 0 = Base Layer
        /*if (!gameObject.CompareTag("Player")) {
            damageScript = GameObject.FindWithTag("Player").GetComponent<Damage>();
        }
        Animator animator = gameObject.GetComponent<Animator>();*/
    }
    void TriggerBloodEffect(Vector3 position)
    {
        // Instantiate the particle system at the desired position
        ParticleSystem blood = Instantiate(bloodParticle, position, Quaternion.identity);
        blood.Play();

        // Destroy the particle system after it finishes
        Destroy(blood.gameObject, 0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void takeDamage(int damage) {
        if (health <= damage) {
            die();
        } else
        {
            health -= damage;
        }
    }

    void die() {
        Destroy(gameObject);
        //cue the unity particle system
        TriggerBloodEffect(gameObject.transform.position);
        if (gameObject.tag == "Player") {
            Invoke("swapScene", 1f);
        }
    }
    void swapScene() {
        SceneManager.LoadScene("MainMenu");
    }
}
