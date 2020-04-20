using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HorizQuestionModalDescription
{
    public HorizQuestionModalDescription(string cancelCaption, ModalAction cancelAction)
    {
        this.cancelCaption = cancelCaption;
        this.cancelAction = cancelAction;
    }

    public HorizQuestionModalDescription(
        string cancelCaption, ModalAction cancelAction,
        string button1Caption, ModalAction button1Action)
    {
        buttonCaptions = new string[1];
        buttonActions = new ModalAction[1];
        buttonCaptions[0] = button1Caption;
        buttonActions[0] = button1Action;
    }

    public HorizQuestionModalDescription(
        string cancelCaption, ModalAction cancelAction, 
        string button1Caption, ModalAction button1Action,
        string button2Caption, ModalAction button2Action)
    {
        this.cancelCaption = cancelCaption;
        this.cancelAction = cancelAction;

        buttonCaptions = new string[2];
        buttonActions = new ModalAction[2];
        buttonCaptions[0] = button1Caption;
        buttonActions[0] = button1Action;
        buttonCaptions[1] = button2Caption;
        buttonActions[1] = button2Action;
    }

    public HorizQuestionModalDescription(
        string cancelCaption, ModalAction cancelAction,
        string button1Caption, ModalAction button1Action,
        string button2Caption, ModalAction button2Action,
        string button3Caption, ModalAction button3Action)
    {
        this.cancelCaption = cancelCaption;
        this.cancelAction = cancelAction;

        buttonCaptions = new string[3];
        buttonActions = new ModalAction[3];
        buttonCaptions[0] = button1Caption;
        buttonActions[0] = button1Action;
        buttonCaptions[1] = button2Caption;
        buttonActions[1] = button2Action;
        buttonCaptions[2] = button3Caption;
        buttonActions[2] = button3Action;
    }

    public string cancelCaption;
    public ModalAction cancelAction;

    public string[] buttonCaptions;
    public ModalAction[] buttonActions;
}
