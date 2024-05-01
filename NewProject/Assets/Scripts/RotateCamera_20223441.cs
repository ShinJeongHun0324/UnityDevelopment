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
        if (!isGameOver) // 게임 오버 상태가 아닐 때만 회전 처리 
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
        }
    }

    // 게임 오버 상태를 설정하는 메서드
    public void SetGameOver()
    {
        isGameOver = true;
    }
}
