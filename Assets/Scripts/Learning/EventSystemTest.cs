using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public interface IRomenoMessageHandler : IEventSystemHandler
{
    void RomenoMessage1();
    void RomenoMessage2();
}

public class EventSystemTest : MonoBehaviour, IRomenoMessageHandler, IMoveHandler, ISubmitHandler, IPointerClickHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnMove(AxisEventData eventData)
    {
        print("Move");
    }

    public void OnSubmit(BaseEventData eventData)
    {
        print("Submit");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RomenoMessage1()
    {
        print("Romeno message1");
    }

    public void RomenoMessage2()
    {
        print("Romeno message2");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        print("Click");
    }
}
