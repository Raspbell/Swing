using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] private GameObject rocket;
    [SerializeField] private AudioClip clip;
    private Rigidbody2D rb;
    private Transform tr;
    private Vector3 vl;
    private RaycastHit2D hit;

    public static bool isClicked = false;
    public static bool isBoosted = false;
    private float mode = 1;

    // Update is called once per frame
    void Update()
    {
        int phase = Display.phase;
        if (phase == 0)
        {
            if (!isClicked)
            {

                if (Input.GetMouseButtonDown(0))
                {
                    hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                    if (hit.collider != null && hit.collider.gameObject.CompareTag("planet"))
                    {
                        isClicked = true;
                    }
                }

                /*if (Input.GetMouseButtonDown(1))
                {
                    hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                    if (hit.collider != null && hit.collider.gameObject.CompareTag("planet"))
                    {
                        isClicked = true;
                        mode = -1;
                    }
                }*/

                if (Input.GetKey(KeyCode.Space))
                {
                    isClicked = true;
                    isBoosted = true;
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                isClicked = false;
            }

            /*if (Input.GetMouseButtonUp(1))
            {
                isClicked = false;
            }*/

            if (Input.GetKeyUp(KeyCode.Space))
            {
                isClicked = false;
                isBoosted = false;
            }
        }
    }

    private void FixedUpdate()
    {
        int phase = Display.phase;
        if (Display.phase == 0)
        {
            if (isClicked)
            {
                if (isBoosted)
                {
                    rb = rocket.GetComponent<Rigidbody2D>();
                    if (rb.velocity.magnitude < 20 && Display.fuel > 0)
                    {
                        Vector3 direction = rb.velocity.normalized;
                        rb.AddForce(direction * 3);
                        
                        Display.fuel -= 0.003f;
                    }
                }
                else
                    addGravity(rocket, hit.collider.gameObject, mode);
            }
        }
        else
        {
            rb = rocket.GetComponent<Rigidbody2D>();
            rb.simulated = false;
        }
    }

    void addGravity(GameObject rocket, GameObject star, float mode)
    {
        tr = star.GetComponent<Transform>();
        //float mass = Mathf.Pow(tr.localScale.x, 2); //星の質量(大きさ)
        float g = 35; //万有引力定数

        rb = rocket.GetComponent<Rigidbody2D>();
        Vector3 dir = (star.transform.position - rocket.transform.position);
        float mag = Mathf.Pow(dir.magnitude, 2);

        //Vector3 force = mode * g * mass * dir / mag;
        Vector3 force = mode * g * dir / mag;
        rb.AddForce(force);

    }
}
