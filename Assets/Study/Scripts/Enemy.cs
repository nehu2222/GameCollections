using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector3 enemyDir;

    void Start()
    {
        int randomValue = UnityEngine.Random.Range(0, 10);
        if(randomValue < 3)
        {
            GameObject target = GameObject.Find("Player");
            enemyDir = target.transform.position - transform.position;
            //Debug.Log("prev : " + enemyDir);
            enemyDir.Normalize();
            //Debug.Log("after : " + enemyDir);
        }
        else
        {
            enemyDir = Vector3.down;   
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += enemyDir * moveSpeed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollision : " + collision.gameObject.name);
        Destroy(collision.gameObject);
        Destroy(this.gameObject);
    }
}
