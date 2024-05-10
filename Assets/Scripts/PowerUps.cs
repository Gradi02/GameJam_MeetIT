using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    private HealthBar healthBar;
    private Strzelaniev2 stl;
    private float timeToResetRate = 0;
    private bool act = false;

    private void Awake()
    {
        healthBar = GetComponent<HealthBar>();
        stl = GetComponent<Strzelaniev2>();
    }

    public void MoreBullets()
    {

    }

    [ContextMenu("test")]
    public void DoubleBulletRate()
    {
        stl.SetRate(0.15f);
        act = true;
        timeToResetRate = Time.time + 10;
    }

    public void GetHp()
    {
        healthBar.AddHealth();
    }

    private void Update()
    {
        if(Time.time > timeToResetRate && act)
        {
            stl.SetRate(0.3f);
            act = false;
        }
    }
}
