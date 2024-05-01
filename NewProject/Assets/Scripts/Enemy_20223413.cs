// using JetBrains.Rider.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_20223413 : MonoBehaviour
{
    public float speed = 3.0f;

    private Rigidbody enemyRb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        //플레이어가 처음부터 있지않고 복사생성되기에 이름으로 찾기보단 태그로 찾기로 한다(복사생성되면 뒤에 (Clone)붙여야 함) -> 정민주 20223413
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection =
            (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
