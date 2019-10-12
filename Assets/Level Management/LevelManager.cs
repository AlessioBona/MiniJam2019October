﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private string targetLevel = "";
    [SerializeField]
    private string mainMenuLevel = "";

    public void ReloadLevel ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadTargetLevel ()
    {
        SceneManager.LoadScene(targetLevel);
    }

    public void LoadMainMenu ()
    {
        Doozy.Engine.GameEventMessage.SendEvent("QuitLevel");
        SceneManager.LoadScene(mainMenuLevel);
    }
}