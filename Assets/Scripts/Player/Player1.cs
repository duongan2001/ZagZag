using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    [SerializeField] GameObject left;

    [SerializeField] float rotateSpeed;
    bool possibleRotate;


    // Start is called before the first frame update
    void Start()
    {
        possibleRotate = true;
    }

    // Update is called once per frame
    void Update()
    {
        CheckRotate();
        Press();

    }

    void Press()
    {
        if (possibleRotate && Input.touchCount != 0)
        {
            Time.timeScale = 1;

            float leftRotate = left.transform.localRotation.z + Time.deltaTime;
            left.transform.Rotate(0, 0, leftRotate * rotateSpeed);
            return;
        }
        else if (!Input.GetMouseButton(0))
        {
            StopPressing();
        }
    }

    void StopPressing()
    {
        if (left.transform.localRotation.z <= 0)
            return;

        float leftRotate = left.transform.localRotation.z - Time.deltaTime;
        left.transform.Rotate(0, 0, -leftRotate * rotateSpeed);

        possibleRotate = true;
    }

    void CheckRotate()
    {
        if (left.transform.localRotation.z > 0.685)
        {
            Debug.Log("false");
            possibleRotate = false;
        }
    }


}
