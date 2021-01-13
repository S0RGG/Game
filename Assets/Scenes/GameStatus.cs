using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    public bool status = false;
    public static GameStatus instatnce = null;
    private void Awake()
    {
        instatnce = this;
    }

    public void GameStatusChange()
    {
        status = !status;
        Debug.Log("Rabotaaet");
    }
}
