using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private float currentTime = 0f;
    public float createTime = 0f;
    public float createMinTime = 1f;
    public float createMaxTime = 5f;
    public GameObject enemyFactory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 enemyDir = Vector3.zero;

        int randomValue = UnityEngine.Random.Range(0, 10);
        if(randomValue < 3)
        {
            GameObject target = GameObject.Find("Player");
            enemyDir = target.transform.position - transform.position;
            Debug.Log("prev : " + enemyDir);
            enemyDir.Normalize();
            Debug.Log("after : " + enemyDir);
        }
        else
        {
            enemyDir = Vector3.down;   
        }

        createTime = UnityEngine.Random.Range(createMinTime, createMaxTime);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= createTime)
        {
            GameObject enemy = Instantiate(enemyFactory, transform.position, quaternion.identity);
            currentTime = 0f;
            createTime = UnityEngine.Random.Range(createMinTime, createMaxTime);
        }
    }
}
