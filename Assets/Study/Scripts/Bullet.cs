using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletMoveSpeed = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.up;
        transform.position += dir * bulletMoveSpeed * Time.deltaTime;
    }
}
