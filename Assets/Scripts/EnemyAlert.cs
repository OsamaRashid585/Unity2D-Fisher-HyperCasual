using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlert : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.GetComponent<Player>() != null)
        {
            var parent = transform.parent.transform;
            var offset = 90f;
            Vector2 direction =  parent.position - collision.transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            var target = Quaternion.Euler(Vector3.forward * (angle + offset));
            parent.rotation = Quaternion.Slerp(parent.rotation, target, 0.05f);
        }

        
    }
}
