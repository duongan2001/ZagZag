using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;
    public GameObject[] levels;
    public GameObject[] goalObjects;

    int currentLevel;

    private void Awake()
    {
        if (levelManager && levelManager != this)
        {
            Debug.Log("Error");
        }
        else
        {
            levelManager = this;
        }

        Time.timeScale = 0f;

        LoadLevel();
    }

    void Start()
    {
        AddLevelGoal();
    }

    public void LoadLevel()
    {

        if (PlayerPrefs.HasKey("currentLevel"))
        {
            if (PlayerPrefs.GetInt("currentLevel") > 20)
            {
                RandomLevel();
            }
            else
            {
                currentLevel = PlayerPrefs.GetInt("currentLevel") - 1;
            }
        }
        else
        {
            PlayerPrefs.SetInt("currentLevel", 1);
            currentLevel = PlayerPrefs.GetInt("currentLevel") - 1;
        }
        Instantiate(LevelManager.levelManager.levels[currentLevel], Vector2.zero, Quaternion.identity);
    }

    void AddLevelGoal()
    {
        goalObjects = GameObject.FindGameObjectsWithTag("Goal");
    }

    public void CheckLevelCompleted()
    {
        int goalCompleteAmount = goalObjects.Length;
        foreach (var item in goalObjects)
        {
            if (item.GetComponent<Goal>().isGoalCompleted == false)
            {
                goalCompleteAmount--;
            }
        }

        if (goalCompleteAmount == goalObjects.Length)
        {
            Time.timeScale = 0;
            UIManager.uiManager.SetSuccessPanelState(true);
        }
        else
        {
            goalCompleteAmount = goalObjects.Length;
        }
    }

    void RandomLevel()
    {
        currentLevel = (int)Random.Range(0, 19.99f);
    }
}
