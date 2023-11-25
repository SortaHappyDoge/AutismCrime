using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class InBetweenBlackout : MonoBehaviour
{
    [Header("UIAttributes")]
    public float blackoutSpeed;
    bool blackOut = false;
    Color tempColor = new Color(0, 0, 0, 0);

    [Header("UIReferences")]
    public RawImage uIBlackout;
    public string scene;

    private void FixedUpdate()
    {
        if (blackOut)
        {
            
            tempColor.a += blackoutSpeed * Time.fixedDeltaTime;
            uIBlackout.color = tempColor;
            if (uIBlackout.color.a < 1) { return; }
            blackOut = false;
            SceneManager.LoadScene(scene);
        }
    }

    public void SwitchScenes(string nextScene) { blackOut = true; scene = nextScene; }
}
