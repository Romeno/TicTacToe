using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ModalManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ShowHorizQuestionModal(Transform parent, bool easyClose, HorizQuestionModalDescription desc)
    {
        GameObject modal = Instantiate(horizQuestionModal, parent);
        HorizQuestionModalStructure modalStruct = modal.GetComponent<HorizQuestionModalStructure>();

        if (easyClose && modalStruct.overlay)
        {
            modalStruct.overlay.onClick.AddListener(() => { desc.cancelAction(modal); });
        }

        for (int i = desc.buttonActions.Length - 1; i >= 0; i--)
        {
            GameObject b = Instantiate(modalStruct.buttonPrefab, modalStruct.buttonsParent.transform);
            b.GetComponent<Button>().onClick.AddListener(ActionWrapper(desc.buttonActions[i], modal));
            b.transform.GetChild(0).GetComponent<Text>().text = desc.buttonCaptions[i];
        }

        GameObject cancelButton = Instantiate(modalStruct.buttonPrefab, modalStruct.buttonsParent.transform);
        cancelButton.GetComponent<Button>().onClick.AddListener(() => { desc.cancelAction(modal); });
        cancelButton.transform.GetChild(0).GetComponent<Text>().text = desc.cancelCaption;
    }

    public void ShowMessageModal(Transform parent, bool easyClose, string buttonCaption, ModalAction buttonAction)
    {
        GameObject modal = Instantiate(horizQuestionModal, parent);
        HorizQuestionModalStructure modalStruct = modal.GetComponent<HorizQuestionModalStructure>();

        if (easyClose && modalStruct.overlay)
        {
            modalStruct.overlay.onClick.AddListener(() => { buttonAction(modal); });
        }

        GameObject b = Instantiate(modalStruct.buttonPrefab, modalStruct.buttonsParent.transform);
        b.GetComponent<Button>().onClick.AddListener(() => { buttonAction(modal); });
        b.transform.GetChild(0).GetComponent<Text>().text = buttonCaption;
    }

    public void ShowInputModal(Transform parent, bool easyClose, InputModalDescription desc)
    {
        GameObject modal = Instantiate(inputModal, parent);
        InputModalStructure modalStruct = modal.GetComponent<InputModalStructure>();

        if (easyClose && modalStruct.overlay)
        {
            modalStruct.overlay.onClick.AddListener(() => { desc.cancelAction(modal); });
        }

        modalStruct.caption.text = desc.windowCaption;
        if (!string.IsNullOrEmpty(desc.bodyText))
        {
            modalStruct.body.text = desc.bodyText;
        }
        else
        {
            modalStruct.body.gameObject.SetActive(false);
        }

        if (!string.IsNullOrEmpty(desc.inputText))
        {
            modalStruct.input.text = desc.inputText;
        }

        if (!string.IsNullOrEmpty(desc.placeholderText))
        {
            modalStruct.input.placeholder.GetComponent<Text>().text = desc.placeholderText;
        }

        GameObject b = null;

        for (int i = desc.buttonActions.Length - 1; i >= 0; i--)
        {
            b = Instantiate(modalStruct.buttonPrefab, modalStruct.buttonsParent.transform);
            b.GetComponent<Button>().onClick.AddListener(ActionWrapper(desc.buttonActions[i], modal));
            b.transform.GetChild(0).GetComponent<Text>().text = desc.buttonCaptions[i];
        }

        b = Instantiate(modalStruct.buttonPrefab, modalStruct.buttonsParent.transform);
        b.GetComponent<Button>().onClick.AddListener(() => { desc.cancelAction(modal); });
        b.transform.GetChild(0).GetComponent<Text>().text = desc.cancelCaption;
    }

    public void ShowVertMenuModal(Transform parent, bool easyClose, VertMenuModalDescription desc)
    {
        GameObject modal = Instantiate(vetrMenuModal, parent);
        VertMenuStructure modalStruct = modal.GetComponent<VertMenuStructure>();

        if (easyClose && modalStruct.overlay)
        {
            modalStruct.overlay.onClick.AddListener(() => { desc.cancelAction(modal); });
        }

        modalStruct.caption.text = desc.windowCaption;

        GameObject b = null;

        for (int i = desc.buttonActions.Count - 1; i >= 0; i--)
        {
            b = Instantiate(modalStruct.buttonPrefab, modalStruct.buttonsParent.transform);
            b.GetComponent<Button>().onClick.AddListener(ActionWrapper(desc.buttonActions[i], modal));
            b.transform.GetChild(0).GetComponent<Text>().text = desc.buttonCaptions[i];
        }

        b = Instantiate(modalStruct.buttonPrefab, modalStruct.buttonsParent.transform);
        b.GetComponent<Button>().onClick.AddListener(() => { desc.cancelAction(modal); });
        b.transform.GetChild(0).GetComponent<Text>().text = desc.cancelCaption;
    }

    private UnityEngine.Events.UnityAction ActionWrapper(ModalAction action, GameObject modal)
    {
        return () => { action(modal); };
    }

    public GameObject horizQuestionModal;
    public GameObject inputModal;
    public GameObject vetrMenuModal;
}

