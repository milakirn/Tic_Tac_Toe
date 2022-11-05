using UnityEngine;

public class Cell : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] playSprites;
    GameObject _board;
    public bool _isPlayed = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        _board = GameObject.Find("Board");
    }

    private void OnMouseDown()
    {
        if (!_isPlayed)
        {
            int spriteIndex = _board.GetComponent<TurnManager>().WhichTurn();
            spriteRenderer.sprite = playSprites[spriteIndex];
            _isPlayed = true;
        }
    }

}