using UnityEngine;

public class Glitter : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float blinkSpeed = 1.5f;
    [SerializeField] private float brightnessMultiplier = 1.5f;

    [Header("References")]
    [SerializeField] private GameObject package;
    [SerializeField] private GameObject customer;
    [SerializeField] private SpriteRenderer packageRenderer;
    [SerializeField] private SpriteRenderer customerRenderer;
    [SerializeField] private Color packageOriginalColor;
    [SerializeField] private Color customerOriginalColor;

    void Start()
    {
        package = GameManager.GM.deliverySpawner.currentPackage;
        customer = GameManager.GM.deliverySpawner.currentCustomer;

        packageRenderer = package.GetComponent<SpriteRenderer>();
        customerRenderer = customer.GetComponent<SpriteRenderer>();

        packageOriginalColor = packageRenderer.color;
        customerOriginalColor = customerRenderer.color;
    }

    void Update()
    {
        if (GameManager.GM.minimapCamera.activeInHierarchy)
        {
            float packageBrightness = Mathf.PingPong(Time.time * blinkSpeed, 1.0f) * brightnessMultiplier; // 밝기 조절
            Color packageBrightColor = packageOriginalColor * packageBrightness; // 원래 색상에 밝기 배율 적용
            packageBrightColor.a = packageOriginalColor.a; // 투명도는 유지
            packageRenderer.color = packageBrightColor;

            float customerBrightness = Mathf.PingPong(Time.time * blinkSpeed, 1.0f) * brightnessMultiplier; // 밝기 조절
            Color customerBrightColor = customerOriginalColor * customerBrightness; // 원래 색상에 밝기 배율 적용
            customerBrightColor.a = customerOriginalColor.a; // 투명도는 유지
            customerRenderer.color = customerBrightColor;
        }
        else
        {
            packageRenderer.color = packageOriginalColor; // 원래 색상 복구
            customerRenderer.color = customerOriginalColor;
        }
    }
}
