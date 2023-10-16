using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour {

    public Image currentHP;
    public Text txt;
    public float HP = 100;
    private float maxHP = 100;
    public static PlayerManager instance;

    // 100/100 = 1 
    // 99/100 = 0.99
    // 50/100 = 0.5


    void Start()
    {
        instance = this;
    }

    void Update()
    {
        float radio = HP / maxHP; // = 100/100 = 1 
        currentHP.rectTransform.localScale = new Vector3(radio, 1, 1);
        txt.text = (radio * 100) + " % ";

        if (HP <= 0)
        {
            HP = 0;
            Invoke("Relife", 3f);
            
        }
    }

    public void Relife()
    {
        SceneManager.LoadScene("MainGame#2");
    }

    public void Healing()
    {
        HP += 10;
        if (HP >= maxHP)
        {
            HP = maxHP;
        }
    }
}
