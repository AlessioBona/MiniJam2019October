using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private string targetLevel = "";

    public void ReloadLevel ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadTargetLevel ()
    {
        SceneManager.LoadScene(targetLevel);
    }
}
