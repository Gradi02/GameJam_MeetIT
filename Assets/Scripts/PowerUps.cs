using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    private HealthBar healthBar;
    private Strzelaniev2 stl;
    private float timeToResetRate = 0;
    private bool act = false;
    private float timeToResetDbl = 0;
    private bool act2 = false;

    private void Awake()
    {
        healthBar = GetComponent<HealthBar>();
        stl = GetComponent<Strzelaniev2>();
    }

    public void FreezeMap()
    {
        FindObjectOfType<AudioManager>().Play("freeze");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject e in enemies)
        {
            if(e.GetComponent<EnemyMovement>() != null)
            {
                e.GetComponent<IFreeze>().FreezeEnemy();
            }
        }
    }
    public void MoreBullets()
    {
        stl.SetBurst(true);
        act2 = true;
        timeToResetDbl = Time.time + 10;
    }

    public void DoubleBulletRate()
    {
        stl.SetRate(0.1f);
        act = true;
        timeToResetRate = Time.time + 10;
    }

    public void AddHp()
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

        if (Time.time > timeToResetDbl && act2)
        {
            stl.SetBurst(false);
            act2 = false;
        }
    }
}

public interface IFreeze
{
    public void FreezeEnemy();
}
