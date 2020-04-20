using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Cell : MonoBehaviour, IPointerClickHandler
{
    public Mark mark;
    public bool canPlaceMark;

    void Start()
    {
        mark = null;
        canPlaceMark = true;

        print(GetComponent<SpriteRenderer>().sprite.pixelsPerUnit);
        print(GetComponent<SpriteRenderer>().sprite.rect);
        print(GetComponent<SpriteRenderer>().bounds);
    }

    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject.Find("TicTacToeGame").GetComponent<TicTacToe>().CellClicked(gameObject);
    }
}
