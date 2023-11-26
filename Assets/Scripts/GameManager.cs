using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject winScreen;
    [SerializeField]
    GameObject loseScreen;
    public GameObject Camera;
    public GameObject player;
    //Reference
    [SerializeField]
    PlayerMovement playerMovement;
    private void Start()
    {
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }
    private void Update()
    {
    }
    public void ActiveWinScreen()
    {
        winScreen.SetActive(true);
    }
    public void ActiveLoseScreen()
    {
        loseScreen.SetActive(true);
    }
}
