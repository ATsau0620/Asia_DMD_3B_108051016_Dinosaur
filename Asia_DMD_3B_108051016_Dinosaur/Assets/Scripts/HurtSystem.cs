using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HurtSystem : MonoBehaviour
{
    [Header("���")]
    public Image imgHpBar;
    [Header("��q")]
    public float hp = 100;

    private float hpMax;

    private void Awake()
    {
        hpMax = hp;
    }
    public void Hurt(float damage)
    {

    }
}

