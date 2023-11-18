using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BlackIn : MonoBehaviour
{
    [Header("UIAttributes")]
    public float blackoutSpeed;
    bool blackIn = true;
    Color tempColor = new Color(0, 0, 0, 1);

    [Header("UIReferences")]
    public RawImage uIBlackout;
    
    private void FixedUpdate()
    {
        if (blackIn)
        {
            tempColor.a -= blackoutSpeed * Time.fixedDeltaTime;
            uIBlackout.color = tempColor;
            if (uIBlackout.color.a > 0) { return; }
            blackIn = false;
            Destroy(gameObject);
        }
    }
}
