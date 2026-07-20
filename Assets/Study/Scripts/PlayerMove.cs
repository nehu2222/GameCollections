using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector3 dir;

    void Start()
    {
        
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //Debug.Log("h :  " + h + " / " + "v : " + v);
        dir = new Vector3(h, v, 0);
        transform.position += dir * moveSpeed * Time.deltaTime;

        //transform.Translate(dir * moveSpeed * Time.deltaTime);
    }
}
