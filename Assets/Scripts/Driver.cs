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
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Rigidbody2D driverRigidbody;
    [SerializeField] private Collider2D driverCollider;

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>(); // 카메라 할당
        }
    }

    void Update()
    {
        // 카메라 따라 움직임
        mainCamera.transform.position = this.transform.position + new Vector3(0, 0, -30);

        // 기본 움직임 (좌우, 상하)
        steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime; // 좌우 무빙 키보드 입력
        moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; // 상하

        transform.Rotate(0, 0, -steerAmount); // steering 조향각 조정
        transform.Translate(0, moveAmount, 0);

    }

    void OnCollisionEnter2D(Collision2D collision) {
        
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Boost")
        {
            Debug.Log("통과");
            driverRigidbody.AddForce(new Vector3(0, moveAmount * boost, -steerAmount), ForceMode2D.Impulse);
        }
    }
}
