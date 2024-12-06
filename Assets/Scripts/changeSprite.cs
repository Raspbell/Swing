using UnityEngine;

public class changeSprite : MonoBehaviour
{
    public Sprite defaultSprite;  // Set your default sprite in the Inspector
    public Sprite hoverSprite;    // Set your hover sprite in the Inspector
    public Sprite clickedSprite;  // Set your clicked sprite in the Inspector
    public AudioClip audioClip;

    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    private bool isClicked = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = defaultSprite;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Display.phase == 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            // Reset sprite to default at the beginning of each frame
            if (!isClicked)
            {
                spriteRenderer.sprite = defaultSprite;
            }

            // Change sprite to hoverSprite if mouse hovers over this object and it's not being clicked
            if (!isClicked && hit.collider != null && hit.collider.gameObject == this.gameObject)
            {
                spriteRenderer.sprite = hoverSprite;
            }

            // Change sprite to clickedSprite when mouse is pressing this object
            if (Input.GetMouseButtonDown(0) && hit.collider != null && hit.collider.gameObject == this.gameObject)
            {
                isClicked = true;
                spriteRenderer.sprite = clickedSprite;
                audioSource.PlayOneShot(audioClip);

            }

            // Reset isClicked to false when mouse is released
            if (Input.GetMouseButtonUp(0))
            {
                isClicked = false;
            }
        }
    }
}
