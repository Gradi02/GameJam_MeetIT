using System.Collections;
using UnityEngine;

public class ShootToMiddle : MonoBehaviour
{
    public int cooldown = 2;
    public GameObject bullet;

    private void Start()
    {
        StartCoroutine(Shooting());
        
    }

    private IEnumerator Shooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(cooldown);
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
}
