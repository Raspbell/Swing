using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class changeButton : MonoBehaviour
{
    public Sprite defaultSprite;  // スプライトA
    public Sprite hoverSprite;    // スプライトB
    public Sprite clickedSprite;  // スプライトC

    public Vector3 textOffset;    // テキストを移動する距離
    public TextMeshProUGUI buttonText;       // ボタンのテキスト

    private Image buttonImage;    // ボタンのImageコンポーネント

    // マウスがホバーしているかどうかのフラグ
    private bool isHovered = false;
    private bool isClicked = false;

    // テキストの元の位置
    private Vector3 originalTextPosition;

    private void Awake()
    {
        buttonImage = GetComponent<Image>();
        originalTextPosition = buttonText.transform.localPosition;
    }

    // マウスがホバーしていない時用のメソッド
    public void OnMouseExit()
    {
        isHovered = false;
        buttonImage.sprite = defaultSprite;
        if (isClicked)
        {
            buttonText.transform.localPosition = originalTextPosition;
        }
    }

    // マウスがホバーしている時用のメソッド
    public void OnMouseOver()
    {
        isHovered = true;
        buttonImage.sprite = hoverSprite;
    }

    // マウスがクリックしている時用のメソッド
    public void OnMouseDown()
    {
        isClicked = true;
        buttonImage.sprite = clickedSprite;
        buttonText.transform.localPosition = originalTextPosition + textOffset;
    }

    // マウスがクリックを離した時用のメソッド
    public void OnMouseUp()
    {
        isClicked = false;
        // ホバー状態によってスプライトを変える
        buttonImage.sprite = isHovered ? hoverSprite : defaultSprite;
        buttonText.transform.localPosition = originalTextPosition;
    }
}