using UnityEngine;

public class timeplus : MonoBehaviour
{

    [SerializeField] private AudioClip audioClip;

    private GameObject player; // �v���C���[��Transform��w�肵�܂��B
    private float detectionRadius = 2.5f; // �v���C���[�����o����锼�a
    private float getRadius = 0.5f;
    private float speed; // �I�u�W�F�N�g���v���C���[�Ɍ������Ĉړ����鑬�x
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        player = GameObject.Find("rocket");
        Transform tr = player.GetComponent<Transform>();
        float distance = Vector3.Distance(tr.position, transform.position);

        // �v���C���[�����o���a��ɂ��邩�m�F���܂��B
        if (distance < detectionRadius)
        {
            // �v���C���[�̕����Ɉ�葬�x�ňړ����܂��B
            Vector3 direction = (tr.position - transform.position).normalized;
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            speed = rb.velocity.magnitude;
            transform.position += direction * speed * Time.deltaTime * 1.5f;
        }

        if (distance < getRadius)
        {
            // �v���C���[�̕����Ɉ�葬�x�ňړ����܂��B
            audioSource = GetComponent<AudioSource>();
            //audioSource.PlayOneShot(audioClip);
            Destroy(gameObject);
            Display.time += 3;
        }
    }
}
