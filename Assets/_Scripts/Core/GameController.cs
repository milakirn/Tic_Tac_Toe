using System.Collections;
using UnityEngine;
using TMPro;


public class GameController : MonoBehaviour
{
    public TurnManager turnManager;
    public GameObject winner;

    private GameObject[] _cells = new GameObject[9];
    private Cell[] _cellObjects = new Cell[9];
    private Sprite[] _cellSprite = new Sprite[9];


    private void Awake()
    {
        turnManager = GetComponent<TurnManager>();
    }

    private void Start()
    {
        for (int i = 0; i < _cells.Length; i++)
        {
            _cells[i] = this.gameObject.transform.GetChild(i).gameObject;
            _cellObjects[i] = _cells[i].GetComponent<Cell>();
        }
    }

    private void Update()
    {
        for (int i = 0; i < _cells.Length; i++)
        {
            _cellSprite[i] = _cellObjects[i].spriteRenderer.sprite;
        }

        bool winner = CheckWinner();
        if (winner || turnManager.turnIndex == 8)
        {
            PauseBeforeRestart();
            StartCoroutine(EndGame(winner));
        }
    }

    public void Restart()
    {
        foreach (Cell cell in _cellObjects)
        {
            cell.spriteRenderer.sprite = null;
            cell._isPlayed = false;
        }
    }

    public void PauseBeforeRestart()
    {
        foreach (Cell cell in _cellObjects)
        {
            cell.spriteRenderer.sprite = null;
            cell._isPlayed = true;
        }
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

        if (CheckValues(0, 4) && CheckValues(0, 8))
            return true;

        if (CheckValues(2, 4) && CheckValues(2, 6))
            return true;

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

    private IEnumerator EndGame(bool isWinner)
    {
        TMP_Text winnerText = winner.GetComponentInChildren<TMP_Text>();

        if (isWinner)
            winnerText.text = turnManager.WhichName() + " IS A WINNER!";
        else
            winnerText.text = "IT'S DRAW!";

        winner.SetActive(true);

        yield return new WaitForSeconds(5.0f);
        turnManager.turnIndex = -1;

        Restart();
        winner.SetActive(false);
    }
}