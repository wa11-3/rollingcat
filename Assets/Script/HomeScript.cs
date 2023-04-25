using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScript : MonoBehaviour
{
    public GameObject levelPanel;
    public GameObject optionsPanel;

    bool levelsview = false;
    bool optionsview = false;


    #region
    public void PlayClick()
    {
        if (!levelsview)
        {
            levelsview = true;
            levelPanel.SetActive(true);
        }
    }

    public void OptionsClick()
    {
        if (!optionsview)
        {
            optionsview = true;
            optionsPanel.SetActive(true);
        }
    }

    public void ExitClick()
    {
        Application.Quit();
    }

    public void CloseClick()
    {
        if (levelsview)
        {
            levelsview = false;
            levelPanel.SetActive(false);
        }

        if (optionsview)
        {
            optionsview = false;
            optionsPanel.SetActive(false);
        }
    }

    public void LevelClick(string level)
    {
        SceneManager.LoadScene(level);
    }
    #endregion
}
