using UnityEngine;
using UnityEngine.EventSystems;

public class boostbutton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        // �{�^���������ꂽ�Ƃ��̏���

        if (!Gravity.isClicked)
        {
            Gravity.isClicked = true;
            Gravity.isBoosted = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
       Gravity.isBoosted = false;
    }
}