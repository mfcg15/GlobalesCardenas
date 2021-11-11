using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int Gems = 0;

    private int gemsInstanciado = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void IncreseGems()
    {
        instance.gemsInstanciado ++;
    }

    public static int GetCountGems()
    {
        return instance.gemsInstanciado;
    }
}
