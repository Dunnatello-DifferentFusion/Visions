using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrajectory : MonoBehaviour
{
    [SerializeField] GunData gunData;
    public Rigidbody rb;
    public Vector3 initialVelocity;

    public float bulletLife = 5.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Ray r = new Ray(transform.position, transform.forward);
        rb.velocity = r.GetPoint(gunData.bulletSpeed) - transform.position;
        Debug.Log(rb.velocity);
        
    }

    public void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity -= new Vector3(0, 9.8f * Time.deltaTime, 0);
        bulletLife -= Time.deltaTime;
        if (bulletLife <= 0 || this.transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }
}
