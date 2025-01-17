using UnityEngine;

public class Glitter : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float blinkSpeed;
    [SerializeField] private float brightnessMultiplier;
    [SerializeField] private float minBrightness;
    [SerializeField] private float localTime;

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

        if (package != null)
            packageRenderer = package.GetComponent<SpriteRenderer>();
        if (customer != null)
            customerRenderer = customer.GetComponent<SpriteRenderer>();

        packageOriginalColor = packageRenderer.color;
        customerOriginalColor = customerRenderer.color;

        localTime = 0f;
    }

    void Update()
    {
        if (GameManager.GM.minimapCamera.activeInHierarchy)
        {
            localTime += Time.deltaTime * blinkSpeed;

            float brightness = Mathf.PingPong(localTime, 1.0f) * brightnessMultiplier;
            brightness = Mathf.Max(brightness, minBrightness);

            if (packageRenderer != null)
            {
                Color packageBrightColor = packageOriginalColor * brightness; // 원래 색상에 밝기 배율 적용
                packageBrightColor.a = packageOriginalColor.a; // 투명도는 유지
                packageRenderer.color = packageBrightColor;
            }
            
            if (customerRenderer != null)
            {
                Color customerBrightColor = customerOriginalColor * brightness; // 원래 색상에 밝기 배율 적용
                customerBrightColor.a = customerOriginalColor.a; // 투명도는 유지
                customerRenderer.color = customerBrightColor;
            }
        }
        else
        {
            if (packageRenderer != null)
                packageRenderer.color = packageOriginalColor; // 원래 색상 복구
            if (customerRenderer != null)
                customerRenderer.color = customerOriginalColor;

            localTime = 0f;
        }
    }
}
