using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class List : MonoBehaviour
{
    [Header("Variables")]
    public Potion pot;
    public int numOrder;
    public int spiceOrder;

    [Header("Images")]
    [SerializeField] Image[] SpiceOrders;
    [SerializeField] Image[] NetOrders;



    [Header("Sprites")]

    
    [SerializeField] Sprite fullSpice;
    [SerializeField] Sprite emptySpice;


    [SerializeField] Sprite fullNet;
    [SerializeField] Sprite emptyNet;


    void Update()
    {



        if(pot.spice > numOrder)
        {
            pot.spice = numOrder;
        }

        for(int i = 0; i < SpiceOrders.Length; i++)
        {
            if(i < pot.spice)
            {
                SpiceOrders[i].sprite = fullSpice;
            } else 
            {
                SpiceOrders[i].sprite = emptySpice;
            }
            if(i < numOrder)
            {
                SpiceOrders[i].enabled = true;
            } else 
            {
                SpiceOrders[i].enabled = false;
            }
        }

        if(pot.net > numOrder)
        {
            pot.net = numOrder;
        }

        for(int i = 0; i < NetOrders.Length; i++)
        {
            if(i < pot.net)
            {
                NetOrders[i].sprite = fullNet;
            } else 
            {
                NetOrders[i].sprite = emptyNet;
            }
            if(i < numOrder)
            {
                NetOrders[i].enabled = true;
            } else 
            {
                NetOrders[i].enabled = false;
            }
        }
    }
}
