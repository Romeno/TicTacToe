using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Cell : MonoBehaviour, IPointerClickHandler
{
    public Mark mark;
    public bool canPlaceMark;

    // Start is called before the first frame update
    void Start()
    {
        mark = null;
        canPlaceMark = true;

        print(GetComponent<SpriteRenderer>().sprite.pixelsPerUnit);
        print(GetComponent<SpriteRenderer>().sprite.rect);
        print(GetComponent<SpriteRenderer>().bounds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject.Find("TicTacToe").GetComponent<TicTacToe>().CellClicked(gameObject);
    }
}
