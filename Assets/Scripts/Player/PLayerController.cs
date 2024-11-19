using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerController : MonoBehaviour
{
    [SerializeField] GameObject left;
    [SerializeField] GameObject right;
    [SerializeField] GameObject jumpDirect;

    [SerializeField] float rotateSpeed;
    [SerializeField] float jumpForce;
    bool possibleRotate;
    bool isJumping;
    [SerializeField] Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        isJumping = false;
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

            if (!isJumping)
            {
                Jump();
            }

            float leftRotate = left.transform.localRotation.z + Time.deltaTime;
            float rightRotate = right.transform.localRotation.z - Time.deltaTime;
            left.transform.Rotate(0, 0, leftRotate * rotateSpeed);
            right.transform.Rotate(0, 0, rightRotate * rotateSpeed);
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
        float rightRotate = right.transform.localRotation.z + Time.deltaTime;
        left.transform.Rotate(0, 0, -leftRotate * rotateSpeed);
        right.transform.Rotate(0, 0, -rightRotate * rotateSpeed);

        possibleRotate = true;
        isJumping = false;
    }

    void CheckRotate()
    {
        if (left.transform.localRotation.z > 0.5)
        {
            possibleRotate = false;
        }
    }

    void Jump()
    {
        float jumpX = jumpDirect.transform.position.x - transform.position.x;
        float jumpY = jumpDirect.transform.position.y - transform.position.y;
        Vector2 jump = new Vector2(jumpX, jumpY);
        rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);
        isJumping = true;
    }
}
