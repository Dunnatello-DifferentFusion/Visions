using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light light;
    public const float flickerDelay = 0.1f;
    public const float flickerFrequencyDecrease = 1.3f;
    public const float baseFlickerFrequency = 0.5f;

    public float currentFlickerFrequency;
    public int decreases = 0;
    
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (decreases > 5)
        {
            decreases = 0;
        }
        if (currentFlickerFrequency <= 0)
        {
            StartCoroutine(flicker(flickerDelay));
            currentFlickerFrequency = Random.Range(baseFlickerFrequency, baseFlickerFrequency + flickerFrequencyDecrease * decreases);
            decreases++;
        }
        else
        {
            currentFlickerFrequency -= Time.deltaTime;
        }
    }

    IEnumerator flicker(float delay)
    {
        light.enabled = false;
        yield return new WaitForSeconds(delay);
        light.enabled = true;
    }
}
