using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator_20223424 : MonoBehaviour
{
    public float rotationSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime); // 아이템 회전
    }
}
