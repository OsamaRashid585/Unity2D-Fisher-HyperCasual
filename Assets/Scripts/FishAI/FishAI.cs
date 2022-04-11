using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAI : MonoBehaviour
{
    private Rigidbody2D _enemyRb2d;
    private float _moveSpeed = 5;
    private float _rotateSpeed = 1.5f;
    private float _timer = 0;
    private float _randomAngle;
    private float _timeToRotate = 4;
    public ParticleSystem BubbleEffect;
    private float _waitForMeatDestory = 0.5f;
    private ParticleSystem _bloodSplash;
    public static bool IsAttackMode = false;

    void Start()
    {
        _enemyRb2d = GetComponent<Rigidbody2D>();
        _bloodSplash = GameObject.FindGameObjectWithTag("BloodSplash").GetComponent<ParticleSystem>();

    }
    private void Update()
    {
        UpgradeToothAI();
        OnKilled();
        MoveForwardAI();
        RotateRandomAI();
    }
    private void MoveForwardAI()
    {
        if (IsAttackMode)
        {
            _moveSpeed = 11f;
            BubbleEffect.enableEmission = true;
        }
        else
        {
            _moveSpeed = 5;
            BubbleEffect.enableEmission = false;

        }
        _enemyRb2d.velocity = transform.up * _moveSpeed;
    }
    private void RotateRandomAI()
    {
        _timer += Time.deltaTime;
        if (_timer >= _timeToRotate)
        {
            _randomAngle = Random.Range(0, 360f);
            _timer = 0;
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
    } 
    private void OnKilled()
    {
        if (FishAITooth.IsKillByEnemy == true)
        {
            _bloodSplash.Play();
            _bloodSplash.transform.position = FishAITooth.EnemyKillPos;
        }
    }
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
    } 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AvoidBorders(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        MeatPickUp(collision);
    }

}
