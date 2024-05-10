using UnityEngine;

public class Strzelaniev2 : MonoBehaviour
{
    [SerializeField]
    public GameObject projectilePrefab1, projectilePrefab2;

    private float nextShot = 0;
    private float nextShotTime = 0.3f;

    private bool normalBullets = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            normalBullets = !normalBullets;
        }

        if (Time.time > nextShot)
        {
            nextShot = Time.time + nextShotTime;
            Instantiate(normalBullets ? projectilePrefab1 : projectilePrefab2, transform.position, transform.rotation);
        }
    }
}
