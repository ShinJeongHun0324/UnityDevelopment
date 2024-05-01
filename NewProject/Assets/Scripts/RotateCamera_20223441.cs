using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;
    public bool isGameOver = false;

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver) // ���� ���� ���°� �ƴ� ���� ȸ�� ó�� 
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
        }
    }

    // ���� ���� ���¸� �����ϴ� �޼���
    public void SetGameOver()
    {
        isGameOver = true;
    }
}
