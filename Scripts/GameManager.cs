using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject winScreen;
    //Reference
    [SerializeField]
    PlayerMovement playerMovement;
    private void Start()
    {
        winScreen.SetActive(false);
    }
   public void ActiveWinScreen()
    {
        winScreen.SetActive(true);
    }
}
