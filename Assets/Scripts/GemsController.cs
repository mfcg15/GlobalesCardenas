using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemsController : MonoBehaviour
{
   
    void Start()
    {

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("Player"))
        {

            GameManager.Gems ++;
            GameManager.instance.IncreseGems();
            Debug.Log("Cantidad de gemas: "+GameManager.Gems);
            Destroy(gameObject);
        }
    }
}
