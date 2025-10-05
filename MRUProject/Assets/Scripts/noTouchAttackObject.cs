using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noTouchAttackObject : MonoBehaviour
{

    public scoreScript scoreS;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("myDamage")) {
            Destroy(gameObject, 0.8f); // selfdestruct
            GameObject txt = GameObject.Find("Score");
            scoreS = txt.GetComponent<scoreScript>(); // Damage dmgScript = col.GetComponent<Damage>();
            scoreS.score += 1;
        }
    }
}
