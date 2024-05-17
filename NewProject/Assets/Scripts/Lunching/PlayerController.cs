using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 20223424, 20223445 ���������� �ε������� ���� �߰�
    public GameObject invincibeIndicator;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private float powerupStrength = 15.0f;

    public GameObject powerupIndicator;
    public float speed = 5.0f;
    public bool hasPowerup = false;

    //���ӿ��� Ȯ�ο� - > ������ 20223413
    public GameManager gameManger;
    // 20223424, 20223445 ���� ���� Ȯ�� �ο� ���� �߰�
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

        //�Ŀ��� ǥ�ø��� y���� �÷��̾� y�� ���� - ������ 20223413
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
        // 20223424, 20223445 ���������� ������ �������� ��������� �ϰ�, �ɷ� Ȱ��ȭ
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
