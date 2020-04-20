using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertMenuModalDescription
{
    public VertMenuModalDescription(
        string windowCaption, 
        string cancelCaption, ModalAction cancelAction)
    {
        this.windowCaption = windowCaption;

        this.cancelCaption = cancelCaption;
        this.cancelAction = cancelAction;

        buttonCaptions = new List<string>();
        buttonActions = new List<ModalAction>();
    }

    public void AddButton(string caption, ModalAction action)
    {
        buttonCaptions.Add(caption);
        buttonActions.Add(action);
    }

    public string windowCaption;

    public string cancelCaption;
    public ModalAction cancelAction;

    public List<string> buttonCaptions;
    public List<ModalAction> buttonActions;
}
