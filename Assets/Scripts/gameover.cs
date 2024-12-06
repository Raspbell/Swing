using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameover : MonoBehaviour
{

    [SerializeField] GameObject ranking;
    [SerializeField] GameObject retry;
    [SerializeField] GameObject quit;

    private Button bt_ranking;
    private Button bt_retry;
    private Button bt_quit;

    // Start is called before the first frame update
    void Start()
    {
        /*ranking.SetActive(false);
        retry.SetActive(false);
        quit.SetActive(false);*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
