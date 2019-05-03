using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DesignCreateMapUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPlayer()
    {
        Transform verticalLayout = GameObject.Find("(P) Map Player Preset").transform;
        var newRow = Instantiate(verticalLayout.GetChild(verticalLayout.childCount - 2).gameObject, verticalLayout) as GameObject;
        newRow.transform.SetSiblingIndex(verticalLayout.childCount - 2);
        verticalLayout.GetChild(verticalLayout.childCount - 3).gameObject.SetActive(true);
    }

    public void RemovePlayer()
    {
        Debug.Log(EventSystem.current.currentSelectedGameObject);
        Object.Destroy(EventSystem.current.currentSelectedGameObject.transform.parent.gameObject);
    }

}
