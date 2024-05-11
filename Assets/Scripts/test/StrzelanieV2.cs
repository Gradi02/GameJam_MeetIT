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
                Quaternion randomRotation1 = Quaternion.Euler(0, 0, Random.Range(-5f, 5f));
                Instantiate(normalBullets ? projectilePrefab1 : projectilePrefab2, transform.position, transform.rotation * randomRotation1);
            }
            else
            {
                Quaternion randomRotation2 = Quaternion.Euler(0, 0, Random.Range(-5f, 5f));
                Quaternion randomRotation3 = Quaternion.Euler(0, 0, Random.Range(-5f, 5f));
                Quaternion randomRotation4 = Quaternion.Euler(0, 0, Random.Range(-5f, 5f));
                Instantiate(normalBullets ? projectilePrefab1 : projectilePrefab2, subPos0.position, transform.rotation * randomRotation2);
                Instantiate(normalBullets ? projectilePrefab1 : projectilePrefab2, subPos1.position, transform.rotation * randomRotation3);
                Instantiate(normalBullets ? projectilePrefab1 : projectilePrefab2, subPos2.position, transform.rotation * randomRotation4);
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
