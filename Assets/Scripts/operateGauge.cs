using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class operateGauge : MonoBehaviour
{

    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = Display.fuel;
    }
}
