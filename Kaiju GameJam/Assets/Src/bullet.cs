using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    GameObject player;
    public float lifeTime;
    float time = 0;
    float distPlay;
    public float distMin;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        time += Time.deltaTime;
        if(time >= lifeTime) { Destroy(gameObject); }
        distPlay = Vector3.Distance(player.transform.position, transform.position);
        if(distPlay <= distMin) { Destroy(gameObject); }
    }
}
