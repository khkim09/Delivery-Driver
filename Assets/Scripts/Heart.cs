using UnityEngine;

public class Heart : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int heartIndex;

    [Header("References")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite onHeart;
    [SerializeField] private Sprite offHeart;

    void Update()
    {
        if (GameManager.GM.lives >= heartIndex)
        {
            spriteRenderer.sprite = onHeart;
        }
        else
        {
            spriteRenderer.sprite = offHeart;
        }
    }
}
