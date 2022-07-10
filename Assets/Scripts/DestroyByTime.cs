using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
  
    public float lifetime = 5; // 5초후 게임오브젝트 제거
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
