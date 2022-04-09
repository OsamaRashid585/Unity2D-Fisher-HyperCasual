using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D PlayerRb2d;
    private float _playerMaxTurnSpeed = 0.25f;
    private float _playerMoveSpeed = 0.2f;
    private float _angle;
    private float _currentRotateVeolcity;
    private Vector2 _playerFinalPos;
    private Vector3 _mousePos;
    public ParticleSystem _bubbleEffect;
    public static float _speedBoostValue = 2;
    private float _waitForMeatDestory = 0.5f;
    private ParticleSystem BloodSplash;
    private AudioSource killsound;
    private RipplePostProcessor ripplecam;

    void Start()
    {
        PlayerRb2d = gameObject.GetComponent<Rigidbody2D>();
        BloodSplash = GameObject.FindGameObjectWithTag("BloodSplash").GetComponent<ParticleSystem>();
        killsound = Camera.main.GetComponent<AudioSource>();
        ripplecam = Camera.main.GetComponent<RipplePostProcessor>();
    }
    void Update()
    {
        Following_Mouse_Position();
        BoostSpeed();
        UpgradeTooth();
        OnKilled();
    }
    private void FixedUpdate()
    {
        PlayerRb2d.MovePosition(_playerFinalPos);
    }
    private void Following_Mouse_Position()
    {
        // follow Position
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _playerFinalPos = Vector2.MoveTowards(transform.position, _mousePos, _playerMoveSpeed);

        //follow rotaion
        Vector2 direction = _mousePos - transform.position;
        float targetAngle = Vector2.SignedAngle(Vector2.up, direction);
        _angle = Mathf.SmoothDampAngle(_angle, targetAngle, ref _currentRotateVeolcity, _playerMaxTurnSpeed);
        transform.eulerAngles = new Vector3(0, 0, _angle);

    }
    private void BoostSpeed()
    {
        if (Input.GetMouseButton(0) && _speedBoostValue >= 0)
        {
            _playerMoveSpeed = 0.7f;
            _bubbleEffect.enableEmission = true;
            _speedBoostValue -= Time.deltaTime;
        }
        else
        {
            _playerMoveSpeed = 0.2f;
            _bubbleEffect.enableEmission = false;

        }
    }
    private void UpgradeTooth()
    {
        if(PlayerTooth._isToothFull == true)
        {
            PlayerTooth._isToothFull = false;
            var tooth = Instantiate(UpgradeManager.Instance.Tooths[0], transform.position, transform.rotation);
            tooth.transform.parent = transform;
            tooth.transform.localPosition = new Vector3(tooth.transform.localPosition.x, tooth.transform.localPosition.y + 2.7f, tooth.transform.localPosition.z);
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
        if (PlayerTooth.IsKillByPlayer == true)
        {
            ripplecam.RippleEffect();
            BloodSplash.Play();
            killsound.Play();
            BloodSplash.transform.position = PlayerTooth._EnemyKillPos;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Meat"))
        {
            collision.transform.position = Vector3.Slerp(collision.transform.position, transform.position, 0.1f);
            _waitForMeatDestory -= Time.deltaTime;
            if(_waitForMeatDestory <= 0)
            {
                Destroy(collision.gameObject);
                _waitForMeatDestory = 0.5f;
            }
        }
        if (collision.gameObject.CompareTag("Powerup"))
        {
            Destroy(collision.gameObject);
            _speedBoostValue += 0.2f;

        }
    }
}
