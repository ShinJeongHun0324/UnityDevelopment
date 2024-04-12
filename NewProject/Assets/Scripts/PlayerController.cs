using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private float powerupStrength = 15.0f;

    // 20223424, 20223445 ���������� �ε������� ���� �߰�
    public GameObject invincibeIndicator;
    public GameObject powerupIndicator;
    public float speed = 5.0f;
    public bool hasPowerup = false;
    public bool isInvincible = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        playerRb.AddForce(focalPoint.transform.forward *
                forwardInput * speed);

        Vector3 piPosition = transform.position;
        piPosition.y = -0.5f;
        powerupIndicator.transform.position = piPosition;
        // 20223424, 20223445 ���������� �ε������Ͱ� �÷��̾ �i�ư����� ����
        invincibeIndicator.transform.position = piPosition;
    }
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;

        powerupIndicator.SetActive(false);
    }
    
    // 20223424, 20223445 ���� ������ Ȱ��ȭ �ð� ���� �޼���
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
