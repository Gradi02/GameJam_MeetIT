using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyType : MonoBehaviour
{
    [SerializeField] private string color;
    public string GetEnemyType()
    {
        return color;
    }
}
