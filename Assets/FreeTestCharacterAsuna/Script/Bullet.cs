using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody bulletRigidbody;

    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vhxHitRed;

    public int damage = 10;
    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        float speed = 30f;
        bulletRigidbody.velocity = transform.forward * speed;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Mob") 
        {
            //hit Mob
            Instantiate(vhxHitRed, transform.position, Quaternion.identity);
        }
        else if(other.name != "pfBulletProjectile(Clone)" && other.name != "colorCube") //총알 오브젝트를 제외하고
        {
            string a = other.name;
            Debug.Log(a);
            //hit else
            Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
   