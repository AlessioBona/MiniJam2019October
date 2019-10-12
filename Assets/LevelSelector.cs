using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Doozy.Engine.UI;
//using UnityEditor.UI;


public class LevelSelector : MonoBehaviour
{

    [SerializeField]
    GameObject levelButtonPrefab;

    [SerializeField]
    List<string> scenesNames;
    [SerializeField]
    List<string> levelsNames;

    List<GameObject> buttonsList;

    [SerializeField]
    GameObject buttonsParent;

    [SerializeField]
    UIView LevelSelectorView;

    private void Start()
    {

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
        buttonsList = new List<GameObject>();
        for (int i = 0; i < scenesNames.Count; i++)
        {
            GameObject newButton = Instantiate(levelButtonPrefab, buttonsParent.transform);
            newButton.GetComponent<LevelSelectButton>().sceneName = scenesNames[i];
            newButton.GetComponentInChildren<Button>().onClick.AddListener(newButton.GetComponent<LevelSelectButton>().LoadTheScene);
            newButton.GetComponentInChildren<Button>().onClick.AddListener(CloseLevelSelect);
        }
    }

    public void CloseLevelSelect()
    {
        LevelSelectorView.Hide();
    }
}
