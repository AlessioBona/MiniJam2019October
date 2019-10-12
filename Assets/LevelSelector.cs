using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelSelector : MonoBehaviour
{

    [SerializeField]
    GameObject LevelButtonPrefab;

    [SerializeField]
    List<string> scenesNames;
    List<string> levelsNames;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        if(scenesNames == null)
        {
            Debug.Log("There are no scene names");
            scenesNames = new List<string>();
        }
        if(levelsNames == null)
        {
            Debug.Log("There are no level names");
            levelsNames = new List<string>();
        }
    }

    public void UpdateLevelSelector()
    {

    }
}
