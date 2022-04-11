using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTooth : MonoBehaviour
{
    private float _spwanPosY = 0.6f;
    private int _headCount;
    public static bool IsToothFull = false;
    public static Vector3 EnemyKillPos;
    public static bool IsKillByPlayer = false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gray"))
        {
            OnKill(collision,0);
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
    }

    private void OnKill(Collider2D collision,int HeadIndex)
    {
       EnemyKillPos = collision.gameObject.transform.position; 
        Destroy(collision.gameObject);
        IsKillByPlayer = true;
        var head = Instantiate(UpgradeManager.Instance.Heads[HeadIndex], transform.parent.position, transform.parent.rotation);
        head.transform.parent = transform.parent;
        head.transform.localPosition = new Vector3(head.transform.localPosition.x, head.transform.localPosition.y + _spwanPosY, head.transform.localPosition.z);
        _spwanPosY += 0.6f;
        UIManager._playerKillScore++;
        _headCount++;
        
        if (_headCount == 6)
        {
            IsToothFull = true;
            _spwanPosY = 0.6f;
        }
    }
}
