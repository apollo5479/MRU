using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreScript : MonoBehaviour
{

    public int score = 0;
    public TMP_Text tmpText;

    // Start is called before the first frame update
    void Start()
    {
        tmpText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        tmpText.text = "Score: " + score;
    }
}
