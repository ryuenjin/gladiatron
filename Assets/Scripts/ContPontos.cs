using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContPontos : MonoBehaviour
{
    public static int PONTOS;
    public GameObject DROP1; //escolhe o objeto CHAVE ser dropado
    void Awake()
    {
        PONTOS = 0;
    }
    void Start()
    {

    }
    void Update()
    {
       // Debug.Log("PONTOS: " + PONTOS);
        DROP_ITEM();
    }
    public void DROP_ITEM()
    {
        if(PONTOS >= 2)
        {
         DROP1.SetActive(true); // dropa a CHAVE
        }
        
    }
}
