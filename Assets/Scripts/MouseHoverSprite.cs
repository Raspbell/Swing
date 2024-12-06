using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseHoverSprite : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite defaultSprite; // Set your default sprite in the Inspector
    public Sprite hoverSprite;   // Set your hover sprite in the Inspector

    private Image spriteImage;   // Reference to the Image component

    private void Awake()
    {
        spriteImage = GetComponent<Image>();
    }

    // When the mouse enters the GameObject
    public void OnPointerEnter(PointerEventData eventData)
    {
        spriteImage.sprite = hoverSprite;
    }

    // When the mouse exits the GameObject
    public void OnPointerExit(PointerEventData eventData)
    {
        spriteImage.sprite = defaultSprite;
    }
}
