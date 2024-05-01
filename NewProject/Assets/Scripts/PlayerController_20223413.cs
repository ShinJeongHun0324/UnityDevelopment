using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_20223413 : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private float powerupStrength = 15.0f;

    public GameObject powerupIndicator;
    public float speed = 5.0f;
    public bool hasPowerup = false;

    //게임오버 확인용 - > 정민주 20223413
    public GameManager_20223413 gameManger;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        focalPoint = GameObject.Find("Focal Point");

        gameManger = GameObject.Find("GameManger_20223413").GetComponent<GameManager_20223413>();
        powerupIndicator = GameObject.FindWithTag("Indicator");
        powerupIndicator.SetActive(false);
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

        // 플레이어가 해당 높이에 있다면 게임오버 처리한다 -> 정민주 20223413
        if(transform.position.y < -10)
        {
            gameManger.gameOver = true;
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;

        powerupIndicator.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
        }

        Debug.Log("powerup");
        powerupIndicator.SetActive(true);
        Debug.Log("start powerup");
        StartCoroutine(PowerupCountdownRoutine());

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
