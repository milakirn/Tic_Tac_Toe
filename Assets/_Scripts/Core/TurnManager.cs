using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{

    private int turnIndex = -1;

    public int WhichTurn()
    {
        turnIndex++;
        return turnIndex % 2;
    }

}
