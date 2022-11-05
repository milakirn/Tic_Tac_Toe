using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    private GameObject[] _cells = new GameObject[9];

    private Cell[] _cellObjects = new Cell[9];

    private Sprite[] _cellSprite = new Sprite[9];


    private void Start()
    {
        for (int i = 0; i < _cells.Length; i++)
        {
            _cells[i] = this.gameObject.transform.GetChild(i).gameObject;
            _cellObjects[i] = _cells[i].GetComponent<Cell>();
            _cellSprite[i] = _cellObjects[i]._spriteRenderer.sprite;
        }
    }

    private void Update()
    {
        bool winner = CheckWinner();
        if (winner)
            Debug.Log("We have a Winner");
    }

    private bool CheckWinner()
    {
        int i = 0;

        for (i = 0; i <= 6; i += 3)
        {
            if (!CheckValues(i, i + 1))
                continue;

            if (!CheckValues(i, i + 2))
                continue;

            return true;
        }

        for (i = 0; i <= 2; i++)
        {
            if (!CheckValues(i, i + 3))
                continue;

            if (!CheckValues(i, i + 6))
                continue;

            return true;
        }


        return false;
    }

    private bool CheckValues(int firstIndex, int secondIndex)
    {
        Sprite firstSprite = _cellSprite[firstIndex];
        Sprite secondSprite = _cellSprite[secondIndex];

        if (firstSprite == null || secondSprite == null)
        {
            // Debug.Log("return false in checkvalues");
            return false;
        }
        if (firstSprite == secondSprite)
        {
            // Debug.Log("Sprites are same");
            return true;
        }
        else
            return false;
    }
}
