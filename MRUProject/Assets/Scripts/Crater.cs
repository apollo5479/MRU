using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crater : MonoBehaviour
{

    public float whenDie = 1.5f;
    public ParticleSystem craterParticle;

    void TriggerCraterEffect(Vector3 position)
    {
        // Instantiate the particle system at the desired position
        ParticleSystem crater = Instantiate(craterParticle, position, Quaternion.identity);
        crater.Play();

        // Destroy the particle system after it finishes
        Destroy(crater.gameObject, 0.7f);
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, whenDie);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
