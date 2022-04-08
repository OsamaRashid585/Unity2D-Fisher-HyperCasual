using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    public GameObject[] EnemyPrefab;
    public GameObject PowerUpPrefab;
    public GameObject MeatPrefab;
    private float MeatPosRX;
    private float MeatPosRY;
    private Vector3 Meatpos;
    private void Start()
    {
        InvokeRepeating("EnemySpawn", 0, 1);
        InvokeRepeating("PowerUpSpawn", 0, 0.1f);
        InvokeRepeating("MeatSpawn", 0, 0.1f);

    }
    private void EnemySpawn()
    {
       if(FindObjectsOfType<Enemy>().Length < 30)
        {
            for (int i = 0; i < 4; i++)
            {
                var posY = Random.Range(-60, 60);
                var posX = Random.Range(-120, 120);
                var pos = new Vector3(posX, posY, 0);
                Instantiate(EnemyPrefab[i], pos, Quaternion.identity);
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
            Instantiate(PowerUpPrefab, pos, Quaternion.identity);
        }
    }

    private void MeatSpawn()
    {
        if(Tooth.IsKill == true)
        {
            for (int i=0; i<5; i++)
            {
                MeatPosRY = Random.Range(-8f, 4f);
                MeatPosRX = Random.Range(-4f, 8f);
                Meatpos = Tooth._playerKIllPos + new Vector3(MeatPosRX, MeatPosRY, 0);
                Instantiate(MeatPrefab, Meatpos, Quaternion.identity);
            }
            Tooth.IsKill = false;
        }
    }
}