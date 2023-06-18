using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonController : MonoBehaviour
{
    public Button[] levelButtons; //Tham chiếu tới button level 2

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (PlayerPrefs.GetInt("Level"+(i+2)+"Unlocked", 0) == 1) 
            {
                levelButtons[i].interactable = true;
            }
            else
            {
                levelButtons[i].interactable = false;
            }
        }
    }
}
