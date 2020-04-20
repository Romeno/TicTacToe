using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GEButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject highlight;
    private Coroutine fadeIn;
    private Coroutine fadeOut;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (highlight)
        {
            Debug.Log("FadeIn");

            if (fadeIn != null)
            {
                StopCoroutine(fadeIn);
            }
            
            if (fadeOut != null)
            {
                StopCoroutine(fadeOut);
            }
            
            fadeIn = StartCoroutine(highlight.GetComponent<Image>().FadeIn(1.0f, 0.33f));
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (highlight)
        {
            Debug.Log("FadeOut");

            if (fadeIn != null)
            {
                StopCoroutine(fadeIn);
            }

            if (fadeOut != null)
            {
                StopCoroutine(fadeOut);
            }
            fadeOut = StartCoroutine(highlight.GetComponent<Image>().FadeOut(0.0f, 0.33f));
        }
    }
}
