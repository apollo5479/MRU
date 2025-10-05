using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUpdate : MonoBehaviour
{
    public Damage damageScript;
    public Slider mainSlider;

    // Start is called before the first frame update
    void Start()
    {
        damageScript = GameObject.FindWithTag("Player").GetComponent<Damage>();
        mainSlider = GetComponent<Slider>();
        //slider = GetComponent<Slider>();
        //playerStats = player.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        mainSlider.value = damageScript.health;
    }
}
