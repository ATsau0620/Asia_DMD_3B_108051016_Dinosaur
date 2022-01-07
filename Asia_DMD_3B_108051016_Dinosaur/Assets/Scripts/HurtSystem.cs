using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HurtSystem : MonoBehaviour
{
    [Header("血條")]
    public Image imgHpBar;
    [Header("血量")]
    public float hp = 100;
    [Header("動畫參數")]
    public string parameterDead = "觸發死亡";
    [Header("死亡事件")]
    public UnityEvent onDead;

    private float hpMax;
    private Animator ani;

    private void Awake()
    {
        ani = GetComponent<Animator>();
        hpMax = hp;
    }

    public void Hurt(float damage)
    {
        hp -= damage;
        imgHpBar.fillAmount = hp / hpMax;
        if (hp <= 0) Dead(); 
    }
    private void Dead()
    {
        ani.SetTrigger(parameterDead);
        onDead.Invoke();
    }
}

