﻿using Doozy.Engine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectButton : MonoBehaviour
{
    public string sceneName { get; set; }

    public void LoadTheScene()
    {
        //Doozy.Engine.GameEventMessage.SendEvent("LevelSelected");
        SceneManager.LoadScene(sceneName);
    }
}