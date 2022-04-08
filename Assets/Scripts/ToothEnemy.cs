using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothEnemy : MonoBehaviour
{
    private float _spwanPosY = 0.6f;
    private int _headCount;
    public static bool _isToothFull = false;

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
            OnKill(collision, 0);
        }
    }

    private void OnKill(Collider2D collision, int HeadIndex)
    {
        Destroy(collision.gameObject);

        var head = Instantiate(KillManger.Instance.heads[HeadIndex], transform.parent.position, transform.parent.rotation);
        head.transform.parent = transform.parent;
        head.transform.localPosition = new Vector3(head.transform.localPosition.x, head.transform.localPosition.y + _spwanPosY, head.transform.localPosition.z);
        _spwanPosY += 0.6f;
        _headCount++;

        if (_headCount == 4)
        {
            _isToothFull = true;
        }
    }
}
