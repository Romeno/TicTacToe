using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputModalDescription
{
    public InputModalDescription(
        string inputText, string placeholderText,
        string windowCaption, string bodyText, 
        string cancelCaption, ModalAction cancelAction)
    {
        this.inputText = inputText;
        this.placeholderText = placeholderText;

        this.windowCaption = windowCaption;
        this.bodyText = bodyText;

        this.cancelCaption = cancelCaption;
        this.cancelAction = cancelAction;
    }

    public InputModalDescription(
        string inputText, string placeholderText,
        string windowCaption, string bodyText,
        string cancelCaption, ModalAction cancelAction,
        string button1Caption, ModalAction button1Action)
    {
        this.inputText = inputText;
        this.placeholderText = placeholderText;

        this.cancelCaption = cancelCaption;
        this.cancelAction = cancelAction;

        buttonCaptions = new string[1];
        buttonActions = new ModalAction[1];
        buttonCaptions[0] = button1Caption;
        buttonActions[0] = button1Action;
    }

    public InputModalDescription(
        string inputText, string placeholderText,
        string windowCaption, string bodyText,
        string cancelCaption, ModalAction cancelAction,
        string button1Caption, ModalAction button1Action,
        string button2Caption, ModalAction button2Action)
    {
        this.inputText = inputText;
        this.placeholderText = placeholderText;

        this.cancelCaption = cancelCaption;
        this.cancelAction = cancelAction;

        buttonCaptions = new string[2];
        buttonActions = new ModalAction[2];
        buttonCaptions[0] = button1Caption;
        buttonActions[0] = button1Action;
        buttonCaptions[1] = button2Caption;
        buttonActions[1] = button2Action;
    }

    public InputModalDescription(
        string inputText, string placeholderText,
        string windowCaption, string bodyText,
        string cancelCaption, ModalAction cancelAction,
        string button1Caption, ModalAction button1Action,
        string button2Caption, ModalAction button2Action,
        string button3Caption, ModalAction button3Action)
    {
        this.inputText = inputText;
        this.placeholderText = placeholderText;

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

    public string inputText;
    public string placeholderText;

    public string windowCaption;
    public string bodyText;

    public string cancelCaption;
    public ModalAction cancelAction;

    public string[] buttonCaptions;
    public ModalAction[] buttonActions;
}
