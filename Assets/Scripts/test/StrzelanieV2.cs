using UnityEngine;

public class Strzelaniev2 : MonoBehaviour
{
    [SerializeField]
    public GameObject projectilePrefab;

    private float nextShot = 0;
    private float nextShotTime = 0.3f;
    void Update()
    {
        if (Time.time > nextShot)
        {
            nextShot = Time.time + nextShotTime;
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }
    }
}
