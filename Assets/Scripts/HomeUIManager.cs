using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeUIManager : MonoBehaviour
{
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject levelPanel;

    public void Play()
    {
        playButton.SetActive(false);
        levelPanel.SetActive(true);
    }

    public void PlayLevel(int level)
    {
        PlayerPrefs.SetInt("currentLevel", level);
        SceneManager.LoadScene(1);
    }

    public void CloseLevelPanel()
    {
        playButton.SetActive(true);
        levelPanel.SetActive(false);
    }
}
