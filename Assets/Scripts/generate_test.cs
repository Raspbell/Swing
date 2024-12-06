using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generate_test : MonoBehaviour
{

    public GameObject planet;
    public float minScale = -0.01f;
    public float maxScale = 0.01f;
    public float minPos = -0.01f;
    public float maxPos = 0.01f;
    public float interval = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                float randomS = Random.Range(minScale, maxScale);
                float randomX = Random.Range(minPos, maxPos);
                float randomY = Random.Range(0, 4);
                float rad = Random.Range(0, 360);


                Vector3 newPos = new Vector3(interval * i + randomX, interval * j + randomY, 0);
                GameObject newObject = Instantiate(planet, newPos, Quaternion.Euler(0, 0, rad * 90));
                newObject.transform.localScale *= randomS;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
