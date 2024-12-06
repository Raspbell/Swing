using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{

    [SerializeField] private GameObject rocket;
    private Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // カメラを特定の位置に移動する
        tr = rocket.GetComponent<Transform>();
        //Camera.main.transform.position = tr.position;
        Camera.main.transform.position = new Vector3(rocket.transform.position.x, rocket.transform.position.y, -10f);

    }
}
