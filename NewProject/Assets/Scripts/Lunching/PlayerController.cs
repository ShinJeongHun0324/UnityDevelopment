using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 20223424, 20223445 무적아이템 인디케이터 변수 추가
    public GameObject invincibeIndicator;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private float powerupStrength = 15.0f;

    public GameObject powerupIndicator;
    public float speed = 5.0f;
    public bool hasPowerup = false;

    //게임오버 확인용 - > 정민주 20223413
    public GameManager gameManger;
    // 20223424, 20223445 무적 여부 확인 부울 변수 추가
    public bool isInvincible = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        focalPoint = GameObject.Find("Focal Point");

        gameManger = FindObjectOfType<GameManager>();
        powerupIndicator = GameObject.FindWithTag("Indicator");
        invincibeIndicator = GameObject.FindWithTag("Invincibe");
        powerupIndicator.SetActive(false);
        invincibeIndicator.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        playerRb.AddForce(focalPoint.transform.forward *
                forwardInput * speed);

        //파워업 표시링의 y값도 플레이어 y를 따라감 - 정민주 20223413
        Vector3 piPosition =  new Vector3(transform.position.x, transform.position.y - 0.5f,
            transform.position.z);

        powerupIndicator.transform.position = piPosition;
        invincibeIndicator.transform.position = piPosition;

    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;

        powerupIndicator.SetActive(false);
    }

    IEnumerator InvincibilityDuration()
    {
        yield return new WaitForSeconds(7);
        isInvincible = false;

        invincibeIndicator.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);

            powerupIndicator.SetActive(true);

            StartCoroutine(PowerupCountdownRoutine());
        }
        // 20223424, 20223445 무적아이템 먹으면 아이템이 사라지도록 하고, 능력 활성화
        else if (other.CompareTag("isInvincible"))
        {
            isInvincible = true;
            Destroy(other.gameObject);

            invincibeIndicator.SetActive(true);

            StartCoroutine(InvincibilityDuration());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody =
            collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.transform.position -
                            transform.position).normalized;

            Debug.Log("Collided with " + collision.gameObject.name +
                " with powerup set to " + hasPowerup);

            enemyRigidbody.AddForce(awayFromPlayer *
                        powerupStrength, ForceMode.Impulse);
        }
    }
}
