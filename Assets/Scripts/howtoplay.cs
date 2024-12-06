using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class howtoplay : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI page1;
    [SerializeField] private TextMeshProUGUI page2;
    [SerializeField] private TextMeshProUGUI page3;
    [SerializeField] private TextMeshProUGUI pagetext;
    [SerializeField] private Image back;
    [SerializeField] private Image right;
    [SerializeField] private Image left;

    private int page;

    private void Update()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        page1.gameObject.SetActive(false);
        page2.gameObject.SetActive(false);
        page3.gameObject.SetActive(false);
        back.gameObject.SetActive(false);
        right.gameObject.SetActive(false);
        left.gameObject.SetActive(false);
        pagetext.gameObject.SetActive(false);
        page = 1;
    }

    public void howtobutton()
    {
        page = 1;
        back.gameObject.SetActive(true);
        right.gameObject.SetActive(true);
        left.gameObject.SetActive(true);
        pagetext.text = "1 / 3";
        pagetext.gameObject.SetActive(true);
        page1.gameObject.SetActive(true);
    }

    public void clickRight()
    {
        if(page == 1)
        {
            page = 2;
            page1.gameObject.SetActive(false);
            page2.gameObject.SetActive(true);
            pagetext.text = "2 / 3";
            return;
        }
        if(page == 2)
        {
            page = 3;
            page2.gameObject.SetActive(false);
            page3.gameObject.SetActive(true);
            pagetext.text = "3 / 3";
            return;
        }
        if(page == 3)
        {
            page = 1;
            page3.gameObject.SetActive(false);
            pagetext.text = "1 / 3";
            Exit();
        }
    }

    public void clickLeft()
    {
        if (page == 1)
        {
            page1.gameObject.SetActive(false);
            pagetext.text = "1 / 3";
            Exit();
            return;
        }
        if (page == 2)
        {
            page = 1;
            page2.gameObject.SetActive(false);
            page1.gameObject.SetActive(true);
            pagetext.text = "1 / 3";
            return;
        }
        if (page == 3)
        {
            page = 2;
            page3.gameObject.SetActive(false);
            page2.gameObject.SetActive(true);
            pagetext.text = "2 / 3";
        }
    }

    void Exit()
    {
        back.gameObject.SetActive(false);
        right.gameObject.SetActive(false);
        left.gameObject.SetActive(false);
        pagetext.gameObject.SetActive(false);
    }

}
