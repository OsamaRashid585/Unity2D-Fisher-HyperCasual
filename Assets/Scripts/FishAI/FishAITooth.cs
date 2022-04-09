using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAITooth : MonoBehaviour
{
    private float _spwanPosY = 0.6f;
    private int _headCount;
    public static bool IsToothFull = false;
    public static bool IsKillByEnemy = false;
    public static Vector3 EnemyKillPos;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gray"))
        {
            OnKill(collision, 0);
        }
        if (collision.gameObject.CompareTag("DarkGreen"))
        {
            OnKill(collision, 1);
        }
        if (collision.gameObject.CompareTag("Yellow"))
        {
            OnKill(collision, 2);
        }
        if (collision.gameObject.CompareTag("Green"))
        {
            OnKill(collision, 3);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            OnKill(collision, 4);
        }
    }

    private void OnKill(Collider2D collision, int HeadIndex)
    {
        switch (gameObject.name)
        {
            case "GrayFishAITooth":
                UIManager.GrayFishAIScore++;
                break;
            case "DarkGreenFishAITooth":
                UIManager.DarkGreenFishAIScore++;
                break;
            case "YellowFishAITooth":
                UIManager.YellowFishAIScore++;
                break;
            case "GreenFishAITooth":
                UIManager.GreenFishAIScore++;
                break;
        }
        Destroy(collision.gameObject);

        var head = Instantiate(UpgradeManager.Instance.Heads[HeadIndex], transform.parent.position, transform.parent.rotation);
        head.transform.parent = transform.parent;
        head.transform.localPosition = new Vector3(head.transform.localPosition.x, head.transform.localPosition.y + _spwanPosY, head.transform.localPosition.z);
        _spwanPosY += 0.6f;
        _headCount++;

        //meat
        EnemyKillPos = collision.gameObject.transform.position;
        IsKillByEnemy = true;

        if (_headCount == 4)
        {
            IsToothFull = true;
            _spwanPosY = 0.6f;

        }
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.IsGameOver = true;
        }
    }

    
}
