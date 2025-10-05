using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCameraMovement : MonoBehaviour
{// Duration of the shake
    //public float shakeDuration = 2f;

    // Strength of the shake
    public float shakeMagnitude = 0.2f;

    // Speed of shake movement
    public float shakeSpeed = 1f;

    private Vector3 initialPosition;
    //private float elapsed = 0f;
    private bool isShaking = false;

    void Start()
    {
        initialPosition = transform.localPosition;
        TriggerShake();
    }

    void Update()
    {
        if (isShaking)
        {
            /*if (elapsed < shakeDuration)
            {*/
                // Calculate smooth shake offset using Perlin noise for natural movement
                float xOffset = (Mathf.PerlinNoise(Time.time * shakeSpeed, 0.0f) - 0.5f) * 2 * shakeMagnitude;
                float yOffset = (Mathf.PerlinNoise(0.0f, Time.time * shakeSpeed) - 0.5f) * 2 * shakeMagnitude;

                transform.localPosition = initialPosition + new Vector3(xOffset, yOffset, 0);

                //elapsed += Time.deltaTime;
            //}
            /*else
            {
                // Reset after shaking ends
                transform.localPosition = initialPosition;
                isShaking = false;
                elapsed = 0f;
            }*/
        }
    }

    // Call this method to start the shake
    public void TriggerShake()
    {
        isShaking = true;
        //elapsed = 0f;
    }

}
