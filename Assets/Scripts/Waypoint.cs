using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Waypoint : MonoBehaviour
{
    // Inspector에서는 접근 가능, 외부 접근 불가능
    [SerializeField] protected float debugDrawRadius = 1.0F;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,
          debugDrawRadius);
    }
}