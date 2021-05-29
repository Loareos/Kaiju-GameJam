using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lilJap : MonoBehaviour
{
    public GameObject player;
    public int bullets;
    public GameObject bullet;
    bool canShoot;
    public float cooldown;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= cooldown)
        {
            shoot();
        }
        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void shoot()
    {
        if(bullets > 0)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
}
