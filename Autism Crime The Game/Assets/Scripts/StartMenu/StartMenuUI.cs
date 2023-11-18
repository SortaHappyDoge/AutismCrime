using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartMenuUI : MonoBehaviour
{
    [Header("UIAttributes")]
    public float blackoutSpeed;
    float currentAlpha = 0;
    bool blackOut = false;
    Color tempColor = new Color(0, 0, 0, 0);

    [Header("UIReferences")]
    public RawImage uIBlackout;
    public string firstScene;

    private void FixedUpdate()
    {
        if (blackOut) 
        {
            tempColor.a += blackoutSpeed * Time.fixedDeltaTime;
            uIBlackout.color = tempColor;
            Debug.Log(uIBlackout.color.a);
            if(uIBlackout.color.a < 1) { return; }
            blackOut = false;
            SceneManager.LoadScene(firstScene);
        }
    }

    public void ExitGame() { Application.Quit(); }
    public void StartGame() { blackOut = true; }
}
