using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Display : MonoBehaviour
{

    [HideInInspector] public static int phase;
    [HideInInspector] public static float fuel;
    public static float dist;
    [SerializeField] private GameObject rocket;
    
    
    private Transform tr;

    [SerializeField] private TextMeshProUGUI text_dist;
    [SerializeField] private TextMeshProUGUI text_time;

    public static float time;
    
    private float dist_max;

    // Start is called before the first frame update
    void Start()
    {
        fuel = 1;
        phase = -1;
        time = 45;
        dist = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (phase == 0)
        {
            time -= Time.deltaTime;
            tr = rocket.GetComponent<Transform>();
            dist = tr.position.magnitude * 1000;
            if (dist > dist_max)
                dist_max = dist;

            text_dist.text = Mathf.Floor(dist_max) + "";
            text_time.text = Mathf.Floor(time) + "";

            if (time <= 0)
            {
                phase = 1;
            }
        }
        if(phase == 1)
        {
            text_time.text = "FINISH!!";
        }
    }
}
