using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float DestroyTime = 2f;
    void Start()
    {
        
    }
    void Update()
    {
        DestroyTime -= Time.deltaTime;

        if (DestroyTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
