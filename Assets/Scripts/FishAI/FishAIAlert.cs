using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAIAlert : MonoBehaviour
{
    private Vector3 AttackPos;
    private void OnTriggerStay2D(Collider2D collision)
    {
        Attack(collision);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<Player>() != null)
        {
            FishAI.IsAttackMode = false;
        }
    }
    private void Attack(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            for (int i = 0; i < collision.transform.childCount; i++)
            {
                if (collision.transform.GetChild(i).CompareTag("Tale"))
                {
                    AttackPos = collision.transform.GetChild(i).transform.position;
                }
            }

            var parent = transform.parent.transform;
            var offset = 90f;
            Vector2 direction = parent.position - AttackPos;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            var target = Quaternion.Euler(Vector3.forward * (angle + offset));
            parent.rotation = Quaternion.Slerp(parent.rotation, target, 0.06f);
            FishAI.IsAttackMode = true;
        }
        if (collision.GetComponent<FishAI>() != null)
        {
            var parent = transform.parent.transform;
            var offset = 90f;
            Vector2 direction = parent.position - collision.transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            var target = Quaternion.Euler(Vector3.forward * (angle + offset));
            parent.rotation = Quaternion.Slerp(parent.rotation, target, 0.07f);
        }
    }

}
