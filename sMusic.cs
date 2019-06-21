using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class sMusic : MonoBehaviour
{
    // Start is called before the first frame update
    float bps;
    int attackMax;
    GameObject babalon;
    void Start()
    {
        bps = MintoSec(70f);
        attackMax = 10;
        babalon = GameObject.Find("Babalon");



    }

    // Update is called once per frame
    void Update()
    {
        float timeing = Timeing();
        int attackDamage = AttackDamage(timeing);
        ScaleBabalon(timeing);




    }
    void ScaleBabalon(float timeing)
    {
        babalon.transform.localScale= new Vector3(timeing,timeing,1);

    }
    int AttackDamage(float timeing)
    {
        timeing = ((-timeing) * attackMax) + attackMax;
        int attackDamage = (int)Math.Round(timeing, 0);
        return attackDamage;


    }
    float Timeing()
    {
        float timeing = Time.time % bps;
        timeing = timeing / bps;

        return timeing;

    }
    float MintoSec(float bpm)
    {
        return bpm / 60f;
    }

}
