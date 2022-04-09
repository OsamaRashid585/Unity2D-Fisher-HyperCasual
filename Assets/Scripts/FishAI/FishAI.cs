using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAI : MonoBehaviour
{
    private Rigidbody2D enemyRb2d;
    private float _moveSpeed = 6;
    private float _rotateSpeed = 1.5f;
    private float timer = 0;
    private float _randomAngle;
    private float _timeToRotate = 4;
    public ParticleSystem _bubbleEffect;
    private float _waitForMeatDestory = 0.5f;
    private ParticleSystem BloodSplash;

    void Start()
    {
        enemyRb2d = GetComponent<Rigidbody2D>();
        BloodSplash = GameObject.FindGameObjectWithTag("BloodSplash").GetComponent<ParticleSystem>();

    }
    private void Update()
    {
        UpgradeToothAI();
        OnKilled();
    }
    private void FixedUpdate()
    {
       MoveForwardAI();
       RotateRandomAI();
    }
    private void MoveForwardAI()
    {
        enemyRb2d.velocity = transform.up * _moveSpeed;

    }
    private void RotateRandomAI()
    {
        timer += Time.deltaTime;
        if (timer >= _timeToRotate)
        {
            _randomAngle = Random.Range(0, 360f);
            timer = 0;
        }

        var targetRotation = Quaternion.Euler(0, 0, _randomAngle);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _rotateSpeed);
    }
    private void UpgradeToothAI()
    {
        if (FishAITooth.IsToothFull == true)
        {
            FishAITooth.IsToothFull = false;
            var localtooth = Instantiate(UpgradeManager.Instance.Tooths[0], transform.position, transform.rotation);
            localtooth.transform.parent = transform;
            localtooth.transform.localPosition = new Vector3(localtooth.transform.localPosition.x, localtooth.transform.localPosition.y + 2.7f, localtooth.transform.localPosition.z);
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).gameObject.tag == "Tooth1" || transform.GetChild(i).gameObject.tag == "DarkGreenHead" || transform.GetChild(i).gameObject.tag == "GrayHead" || transform.GetChild(i).gameObject.tag == "GreenHead" || transform.GetChild(i).gameObject.tag == "YellowHead")
                {
                    Destroy(transform.GetChild(i).gameObject);
                }

            }
        }
    } //i
    private void OnKilled()
    {
        if (FishAITooth.IsKillByEnemy == true)
        {
            BloodSplash.Play();
            BloodSplash.transform.position = FishAITooth.EnemyKillPos;
        }
    } //i
    private void AvoidBorders(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            transform.Rotate(0, 0, 180);

        }
    }
    private void MeatPickUp(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Meat"))
        {
            collision.transform.position = Vector3.Slerp(collision.transform.position, transform.position, 0.1f);
            _waitForMeatDestory -= Time.deltaTime;
            if (_waitForMeatDestory <= 0)
            {
                Destroy(collision.gameObject);
                _waitForMeatDestory = 0.5f;
            }
        }
    } //i
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AvoidBorders(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        MeatPickUp(collision);
    }

}
