using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBar : MonoBehaviour
{
    [Header("BarReferences")]
    public Transform background;
    public Transform bar;

    [Header("BarAttributes")]
    public float maxBarSize = 0.33f;
    float currentProgress;
    // Update is called once per frame
    void Update()
    {
        
        if(currentProgress > -0.33f)
        {
            bar.GetComponent<SpriteRenderer>().size = new(0.32f, currentProgress);
            background.gameObject.SetActive(true);
            bar.gameObject.SetActive(true);
            if (bar.GetComponent<SpriteRenderer>().size.y <= 0)
            {
                background.gameObject.SetActive(false);
                bar.gameObject.SetActive(false);
            }
            return;
        }
        background.gameObject.SetActive(false);
        bar.gameObject.SetActive(false);
        
    }

    public void StaminaRemap(float value, float from1, float to1)
    {
        currentProgress = (value - from1) / (to1 - from1) * (0.33f - 0) + 0;
    }
}
