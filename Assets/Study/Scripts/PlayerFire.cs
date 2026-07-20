using Unity.Mathematics;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;
    public GameObject bulletPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletFactory, bulletPosition.transform.position, quaternion.identity);
        }
    }
}
