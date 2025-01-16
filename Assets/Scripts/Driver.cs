using UnityEngine;

public class Driver : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float steerSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float boost;
    [SerializeField] private float brake;
    [SerializeField] private float steerAmount;
    [SerializeField] private float moveAmount;

    [Header("References")]
    [SerializeField] private Rigidbody2D driverRigidbody;
    [SerializeField] private Collider2D driverCollider;

    void Update()
    {
        // 기본 움직임 (좌우, 상하)
        steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime; // 좌우 무빙 키보드 입력
        moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; // 상하

        transform.Rotate(0, 0, -steerAmount); // steering 조향각 조정
        transform.Translate(0, moveAmount, 0);

        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    void StartDeliver()
    {
        GameManager.GM.hasPackage = true;
        Debug.Log("배달 시작");
    }

    void CompleteDeliver()
    {
        GameManager.GM.hasPackage = false;
        Debug.Log("배달 완료");
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Package")
        {
            Destroy(collider.gameObject);
            StartDeliver();
        }

        if (collider.tag == "Customer" && GameManager.GM.hasPackage)
        {
            Destroy(collider.gameObject);
            CompleteDeliver();
        }
    }
}
