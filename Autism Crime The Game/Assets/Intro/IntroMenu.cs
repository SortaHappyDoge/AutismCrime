using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroMenu : MonoBehaviour
{
    public Animator animator;
    public AnimationClip portalVacuum;
    int page = 0;
    public Transform page0;
    public Transform page1;
    public Transform page2;
    public Transform page3;
    public Transform page4;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            page++;
            
        }
        if (page == 0)
        {
            page0.gameObject.SetActive(true);
        }
        else if (page == 1)
        {
            page0.gameObject.SetActive(false);
            page1.gameObject.SetActive(true);
        }
        else if (page == 2)
        {
            page1.gameObject.SetActive(false);
            page2.gameObject.SetActive(true);
        }
        else if (page == 3)
        {
            page2.gameObject.SetActive(false);
            page3.gameObject.SetActive(true);
        }
        else if(page == 4)
        {
            page3.gameObject.SetActive(false);
            animator.enabled = true;
        }
        else
        {
            SceneManager.LoadScene("Medieval");
        }
    }
}
