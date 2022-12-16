using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private bool gameEnded;

    public void WinGame(){

        if(!gameEnded){
        Debug.Log("You win!");
        gameEnded = true;
    }

}

}