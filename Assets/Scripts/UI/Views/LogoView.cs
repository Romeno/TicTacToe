using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoView : MonoBehaviour
{
    private float startTime;
    private bool finishing;
    private bool openAnimFinished;

    void Start()
    {
        Init();
    }

    public void Init()
    {
        startTime = Time.time;
        finishing = false;
        openAnimFinished = false;
    }

    public void PlaySound()
    {
        //GetComponent<AudioSource>().
    }

    void Update()
    {
        var a = GetComponent<Animator>();

        if (finishing && a.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !a.IsInTransition(0) && a.GetCurrentAnimatorStateInfo(0).IsName("LogoClose"))
        {
            TicTacToeGlobal.views.ActivateMainMenuView();
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!finishing)
            {
                FinishAnim();
            }
        }

        if (openAnimFinished && !finishing)
        {
            if (Time.time - startTime > 2)
            {
                FinishAnim();
            }
        }
    }

    void FinishAnim()
    {
        var a = GetComponent<Animator>();

        finishing = true;
        a.SetTrigger("Finish");
    }

    void AnimFinishedEvent()
    {
        openAnimFinished = true;
    }
}
