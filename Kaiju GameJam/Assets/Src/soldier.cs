using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soldier : MonoBehaviour {

    public bool absorb = false;
	public int life, damage;
    float distPlay;

    //__TIR_____________________
    public GameObject bulletPref;
    public float cooldown;
    float time;
    int panpan = 10;
    GameObject player;
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        distPlay = Vector3.Distance(player.transform.position, transform.position);
        if (distPlay < 0.8f)
            absorb = true;

        if (!absorb) {
            time += Time.deltaTime;
            if (time >= cooldown) {
                shoot(false);
                time = 0;
            }
        }

        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if(distPlay > 5) {
            transform.Translate(Vector3.right * Time.deltaTime);
        }

        if(distPlay < 3 && absorb == false) {
            transform.Translate(Vector3.left * Time.deltaTime);
        }

        if (absorb) {
            transform.parent = player.transform;
            transform.Rotate(new Vector3(0, 0, 180));

            time += Time.deltaTime;

            if(time > cooldown && panpan > 0) {
                shoot(true);
                panpan--;
                time = 0;
            }

            if(panpan <= 0) {
                player.GetComponent<character>().eat_count++;
                Destroy(gameObject);
            }
        }
    }

    void shoot(bool from_player) {
        GameObject go = Instantiate(bulletPref, transform.position, transform.rotation);
		bullet bul = go.GetComponent<bullet>();
        Rigidbody2D rb = go.GetComponent<Rigidbody2D>();

		bul.damage = damage;
        bul.playerAbs = from_player;
        rb.AddForce(transform.right * bul.speed, ForceMode2D.Impulse);
    }
}
