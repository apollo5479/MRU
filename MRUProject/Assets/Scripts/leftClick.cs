using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftClick : MonoBehaviour
{
    //public Animator animator;
    //public Damage dmgScript;
    //public GameObject hitBox;
    public GameObject targetObject;
    public BoxCollider boxCollider;
    public float toggleInterval = 1f;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider>();
        //boxCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        //Debug.Log(other.tag);
        if (other.gameObject.tag == "Tank" || other.gameObject.tag == "Mage")
        {
            GameObject col = other.gameObject;
            Damage dmgScript = col.GetComponent<Damage>();
            //Debug.Log(other.name + " has entered");
            GameObject txt = GameObject.Find("Score");

            dmgScript = other.gameObject.GetComponent<Damage>();
            Destroy(gameObject, 1f);
            dmgScript.takeDamage(1); 
        }
        
    }
    /*private IEnumerator ToggleRoutine()
    {
        while (true)
        {
            targetObject.SetActive(!targetObject.activeSelf); // Toggle active state
            yield return new WaitForSeconds(toggleInterval); // Wait for the interval
        }
    }*/
    public void goVisible()
    {
        //StartCoroutine(ToggleRoutine());
        boxCollider.enabled = true;
        //hitBox.enabled = true;
        //targetObject.SetActive(!targetObject.activeSelf);
        //Invoke("goInvis", 1f);
    }

    void goInvis() {
        boxCollider.enabled = false;
    }
}
