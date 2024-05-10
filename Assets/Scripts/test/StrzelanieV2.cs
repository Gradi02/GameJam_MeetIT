using UnityEngine;

public class Strzelaniev2 : MonoBehaviour
{
    [SerializeField]
    public GameObject projectilePrefab;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation, this.gameObject.transform);
        }
    }
}
