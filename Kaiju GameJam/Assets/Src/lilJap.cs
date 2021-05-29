using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lilJap : MonoBehaviour
{
    public GameObject player;
    float distPlay;

    //__TIR_____________________
    public GameObject bulletPref;
    public float cooldown;
    float time;
    public float bulletForce;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distPlay = Vector3.Distance(player.transform.position, transform.position);
        if (distPlay < 1) { player.GetComponent<PlayerMove>().comida++; Destroy(gameObject); }
        time += Time.deltaTime;
        if(time >= cooldown)
        {
            shoot();
            time = 0;
        }
        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        if(distPlay > 5)
        {
            transform.Translate(Vector3.right * Time.deltaTime);
        }
        if(distPlay < 3)
        {
            transform.Translate(Vector3.left * Time.deltaTime);
        }
    }

    void shoot()
    {
        GameObject bullet = Instantiate(bulletPref, transform.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
    }
}
