using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showResult : MonoBehaviour
{
    private int count;
    private int score;
    private Animator anim1;
    private Animator anim2;
    private Animator anim3;
    private AudioSource audioSource;

    [SerializeField] private Button button1;
    [SerializeField] private Button button2;
    [SerializeField] private Button button3;
    [SerializeField] private AudioClip audioClip;

   

    //private Display display;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        GameObject obj1 = GameObject.Find("score (TMP)");
        GameObject obj2 = GameObject.Find("gauge frame");
        GameObject obj3 = GameObject.Find("Panel");
        anim1 = obj1.GetComponent<Animator>();
        anim2 = obj2.GetComponent<Animator>();
        anim3 = obj3.GetComponent<Animator>();
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
        button3.gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Display.phase == 1)
        {
            anim1.SetBool("endgame", true);
            anim2.SetBool("endgame", true);
            score = (int)(Display.dist);
            
        }
    }

    private void FixedUpdate()
    {
        if (Display.phase == 1 && count == 0)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioClip);
        }
        if (Display.phase == 1 && count < 150)
        {
            count++;
        }
        if (Display.phase == 1 && count == 100)
        {
            anim3.SetBool("endgame", true);
            button1.gameObject.SetActive(true);
            button2.gameObject.SetActive(true);
            button3.gameObject.SetActive(true);
        }
        if (Display.phase == 1 && count == 150)
        {
            naichilab.RankingLoader.Instance.SendScoreAndShowRanking(score);
            Display.phase = 2;
        }
    }
}
