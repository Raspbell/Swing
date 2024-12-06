using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    private AudioSource source;
    private Rigidbody2D rb;
    private Transform tr;
    private Vector3 vl;

    private int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        source = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if(Display.phase == -1 && count < 135)
        {
            count++;
        }

        if(Display.phase == -1 && count == 135)
        {
            Display.phase = 0;
            rb =this.GetComponent<Rigidbody2D>();
            rb.simulated = true;
            rb = this.GetComponent<Rigidbody2D>();
            Vector3 force = new Vector3(80.0f, 0.0f, 0.0f);
            rb.AddForce(force);
            count = 0;
        }

        rb = this.GetComponent<Rigidbody2D>();
        tr = this.GetComponent<Transform>();

        vl = rb.velocity;
        //float rad = Mathf.Atan2(vl.y, vl.x) * 180 / Mathf.PI;
        //tr.rotation = Quaternion.Euler(0, 0, rad);
        transform.right = vl;
    }

    private void Update()
    {
        if (Gravity.isBoosted)
        {
            source.Play();
        }
        else
        {
            source.Stop();
        }
    }
}
