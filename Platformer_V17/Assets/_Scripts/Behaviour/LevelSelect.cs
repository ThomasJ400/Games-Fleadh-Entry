using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour {
    public Button[] levelButtons;

    private void Start()
    {
        switchButtons();
    }

    private void switchButtons()
    {
        Debug.Log("Completed Levels: " + PersistentData.instance.completedLevels);
        foreach (Button button in levelButtons)
        {
            button.interactable = false;
        }

        for (int i = 0; i < PersistentData.instance.completedLevels; i++)
        {
            Debug.Log("Buttons");
            levelButtons[i].interactable = true;
        }
    }
}
