using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Goal : MonoBehaviour
{
    float time = 3;
    [SerializeField] Animator animator;
    public bool isGoalCompleted;

    void ReachGoal()
    {
        time -= Time.deltaTime;
        animator.SetBool("Collide", true);

        if (time <= 0)
        {
            GoalComplete(true);
            LevelManager.levelManager.CheckLevelCompleted();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            ReachGoal();
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            ReachGoal();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            time = 3;
            animator.SetBool("Collide", false);
            GoalComplete(false);
        }
    }

    public void GoalComplete(bool state)
    {
        isGoalCompleted = state;
    }
}
