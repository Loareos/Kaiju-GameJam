using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float DG;
    float HB;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DG = Input.GetAxis("Horizontal") * speed;
        HB = Input.GetAxis("Vertical") * speed;
        transform.Translate(new Vector3(DG, HB, 0).normalized * speed);
    }
}
