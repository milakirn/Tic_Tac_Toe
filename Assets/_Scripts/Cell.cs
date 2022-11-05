using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public SpriteRenderer _spriteRenderer;
    public Sprite[] playSprites;
    GameObject _board;
    public bool _isPlayed = false;
    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _board = GameObject.Find("Board");
    }
    private void Start()
    {
        _spriteRenderer.sprite = null;
    }

    private void OnMouseDown() 
    {
        if (!_isPlayed)
        {
            int spriteIndex = _board.GetComponent<TurnManager>().WhichTurn();
            _spriteRenderer.sprite = playSprites[spriteIndex];
            _isPlayed = true;
        }
    }

}