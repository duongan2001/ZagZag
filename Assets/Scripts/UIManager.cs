using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager uiManager;

    [SerializeField] Text levelText;
    [SerializeField] GameObject musicOn;
    [SerializeField] GameObject musicOff;
    [SerializeField] GameObject successPanel;
    [SerializeField] GameObject failPanel;
    [SerializeField] GameObject nextLevelButton;
    [SerializeField] GameObject maxLevelButton;

    //bool musicState = true;

    private void Awake()
    {
        if (uiManager && uiManager != this)
        {
            Debug.Log("Error");
        }
        else
        {
            uiManager = this;
        }

    }

    private void Start()
    {
        SetLevelText();
    }

    void SetLevelText()
    {
        levelText.text = "Level " + PlayerPrefs.GetInt("currentLevel");
    }

    public void SetSuccessPanelState(bool state)
    {
        successPanel.SetActive(state);
        if (PlayerPrefs.GetInt("currentLevel") == 20)
        {
            PlayerPrefs.SetInt("currentLevel", 20);
            nextLevelButton.SetActive(false);
            maxLevelButton.SetActive(true);
        }
    }

    public void SetFailPanelState(bool state)
    {
        failPanel.SetActive(state);
    }

    public void TurnOnMusic()
    {
        musicOn.SetActive(true);
        musicOff.SetActive(false);
    }

    public void TurnOffMusic()
    {
        musicOn.SetActive(false);
        musicOff.SetActive(true);
    }

    public void Replay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void Home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("currentLevel", PlayerPrefs.GetInt("currentLevel") + 1);
        SceneManager.LoadScene(1);
    }
}
