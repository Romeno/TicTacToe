using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoView : MonoBehaviour
{
    private float startTime;
    private bool finishing;
    private bool openAnimFinished;

    // Start is called before the first frame update
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

    // Update is called once per frame
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

        // if animation finished
        if (a.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !a.IsInTransition(0) && !finishing)
        {
            openAnimFinished = true;
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
}
