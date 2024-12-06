using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatePlanets : MonoBehaviour
{

    [SerializeField] private GameObject planet;
    public float minScale = 1;
    public float maxScale = 5;

    private float detectionRadius = 30.0f;
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
        
        int planetCount = 0;  // "planet"�^�O�̐���J�E���g���邽�߂̕ϐ�

        

        // �e�R���C�_�[�̃^�O��`�F�b�N
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.tag == "planet")
            {
                planetCount++;  // "planet"�^�O����I�u�W�F�N�g�𔭌����邽�тɃJ�E���g�𑝂₷
            }
        }

        if (planetCount < 30)
        {
            float randomR = Random.Range(minRadius, maxRadius);
            float randomT = Random.Range(0, 360);
            float randomS = Random.Range(minScale, maxScale);
            float rad = Random.Range(0, 4);
            Vector3 newPos = PolarToCartesian(randomR, randomT);

            hitColliders = Physics2D.OverlapCircleAll(transform.position + newPos, randomS * 1.5f);

            if (hitColliders.Length==0)
            {
                GameObject newObject = Instantiate(planet, transform.position + newPos, Quaternion.Euler(0, 0, rad * 90));
                newObject.transform.localScale *= randomS;
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
