using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject _powerUpClonesParent;
    public GameObject _enemyAIClonesParent;
    public GameObject[] EnemyPrefab;
    public GameObject PowerUpPrefab;
    public GameObject MeatPrefab;
    private float _meatPosRX;
    private float _meatPosRY;
    private Vector3 _meatpos;

    private void Start()
    {
        InvokeRepeating("EnemySpawn", 0, 0.1f);
        InvokeRepeating("PowerUpSpawn", 0, 0.1f);
        InvokeRepeating("MeatSpawn", 0, 0.1f);

    }
    private void EnemySpawn()
    {
       if(FindObjectsOfType<FishAI>().Length < 30)
        {
            for (int i = 0; i < 4; i++)
            {
                var posY = Random.Range(-60, 60);
                var posX = Random.Range(-120, 120);
                var pos = new Vector3(posX, posY, 0);
                var EnemyAIClone = Instantiate(EnemyPrefab[i], pos, Quaternion.Euler(0,0,posY));
                EnemyAIClone.transform.parent = _enemyAIClonesParent.transform;
            }
        }
    }
    private void PowerUpSpawn()
    {
        if (GameObject.FindGameObjectsWithTag("Powerup").Length != 200)
        {
            var posY = Random.Range(-70, 70);
            var posX = Random.Range(-130, 130);
            var pos = new Vector3(posX, posY, 0);
            var PowerUPClone = Instantiate(PowerUpPrefab, pos, Quaternion.identity);
            PowerUPClone.transform.parent = _powerUpClonesParent.transform;
        }
    }
    private void MeatSpawn()
    {
        if(PlayerTooth.IsKillByPlayer == true)
        {
            for (int i=0; i<5; i++)
            {
                _meatPosRY = Random.Range(-8f, 4f);
                _meatPosRX = Random.Range(-4f, 8f);
                _meatpos = PlayerTooth._EnemyKillPos + new Vector3(_meatPosRX, _meatPosRY, 0);
                Instantiate(MeatPrefab, _meatpos, Quaternion.identity);
            }
            PlayerTooth.IsKillByPlayer = false;
        }
        if (FishAITooth.IsKillByEnemy == true)
        {
            for (int i = 0; i < 2; i++)
            {
                _meatPosRY = Random.Range(-8f, 4f);
                _meatPosRX = Random.Range(-4f, 8f);
                _meatpos = FishAITooth.EnemyKillPos + new Vector3(_meatPosRX, _meatPosRY, 0);
                Instantiate(MeatPrefab, _meatpos, Quaternion.identity);
            }
            FishAITooth.IsKillByEnemy = false;
        }
    }
}
