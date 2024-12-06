using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateItems : MonoBehaviour
{

    [SerializeField] private GameObject time;
    [SerializeField] private GameObject fuel;

    private float detectionRadius = 10.0f;
    private float minRadius = 20.0f;
    private float maxRadius = 40.0f;

    void Update()
    {
        CountPlanets();
    }

    void CountPlanets()
    {
        // ���m�͈͓�̑S�ẴR���C�_�[��擾
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);

        int timeCount = 0;
        int fuelCount = 0;

        // �e�R���C�_�[�̃^�O��`�F�b�N
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.tag == "time")
            {
                timeCount++;  // "planet"�^�O����I�u�W�F�N�g�𔭌����邽�тɃJ�E���g�𑝂₷
            }

            if (hitCollider.tag == "fuel")
            {
                fuelCount++;  // "planet"�^�O����I�u�W�F�N�g�𔭌����邽�тɃJ�E���g�𑝂₷
            }
        }
        //Debug.Log(timeCount);

        if (timeCount < 5)
        {
            timeCount = 0;
            float randomR = Random.Range(minRadius, maxRadius);
            float randomT = Random.Range(0, 360);
            Vector3 newPos = PolarToCartesian(randomR, randomT);

            hitColliders = Physics2D.OverlapCircleAll(transform.position + newPos, 13.0f);

            foreach (var hitCollider in hitColliders)
            {
                timeCount++;
                /*if (hitCollider.tag == "time")
                {
                    timeCount++;  // "planet"�^�O����I�u�W�F�N�g�𔭌����邽�тɃJ�E���g�𑝂₷
                }*/
            }

            if (timeCount == 0)
            {
                GameObject newObject = Instantiate(time, transform.position + newPos, Quaternion.Euler(0, 0, 0));
            }
        }

        if (fuelCount < 10)
        {
            fuelCount = 0;
            float randomR = Random.Range(minRadius, maxRadius);
            float randomT = Random.Range(0, 360);
            Vector3 newPos = PolarToCartesian(randomR, randomT);

            hitColliders = Physics2D.OverlapCircleAll(transform.position + newPos, 13.0f);

            foreach (var hitCollider in hitColliders)
            {
                fuelCount++;
                /*if (hitCollider.tag == "fuel")
                {
                    fuelCount++;  // "planet"�^�O����I�u�W�F�N�g�𔭌����邽�тɃJ�E���g�𑝂₷
                }*/
            }

            if (fuelCount == 0)
            {
                GameObject newObject = Instantiate(fuel, transform.position + newPos, Quaternion.Euler(0, 0, 0));
            }
        }
    }

    Vector3 PolarToCartesian(float r, float angleDegrees)
    {
        float theta = Mathf.Deg2Rad * angleDegrees;  // Convert angle to radians
        float x = r * Mathf.Cos(theta);
        float y = r * Mathf.Sin(theta);
        return new Vector3(x, y, 0);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
