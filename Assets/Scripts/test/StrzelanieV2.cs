using UnityEngine;

public class Strzelaniev2 : MonoBehaviour
{
    [SerializeField]
    public GameObject projectilePrefab1, projectilePrefab2;

    [SerializeField]
    private Transform subPos0, subPos1, subPos2;

    public float startSpawnTime;

    private float nextShot = 0;
    private float nextShotTime = 0.3f;

    private bool normalBullets = false;
    private bool burst = false;

    private void Awake()
    {
        nextShot = Time.time + startSpawnTime;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            normalBullets = !normalBullets;
        }

        if (Time.time > nextShot)
        {
            nextShot = Time.time + nextShotTime;

            if (!burst)
            {
                Instantiate(normalBullets ? projectilePrefab1 : projectilePrefab2, transform.position, transform.rotation);
            }
            else
            {
                Instantiate(normalBullets ? projectilePrefab1 : projectilePrefab2, subPos0.position, transform.rotation);
                Instantiate(normalBullets ? projectilePrefab1 : projectilePrefab2, subPos1.position, transform.rotation);
                Instantiate(normalBullets ? projectilePrefab1 : projectilePrefab2, subPos2.position, transform.rotation);
            }
        }
    }

    public void SetRate(float n)
    {
        nextShotTime = n;
    }

    public void SetBurst(bool br)
    {
        burst = br;
    }
}
