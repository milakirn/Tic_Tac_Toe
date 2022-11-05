using UnityEngine;

public class TurnManager : MonoBehaviour
{

    public int turnIndex = -1;

    public int WhichTurn()
    {
        turnIndex++;

        return turnIndex % 2;
    }

    public string WhichName()
    {
        string turnName;

        if (turnIndex % 2 == 0)
            turnName = "X";
        else
            turnName = "O";

        return turnName;
    }

}
