using UnityEngine;

public class PlayerCar : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float steerSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float boost;
    [SerializeField] private float brake;

    [Header("References")]
    [SerializeField] private Rigidbody2D driverRigidbody;
    [SerializeField] private Collider2D driverCollider;

    void Update()
    {
        // 기본 움직임 (좌우, 상하)
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime; // 좌우 무빙 키보드 입력
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; // 상하

        transform.Rotate(0, 0, -steerAmount); // steering 조향각 조정
        transform.Translate(0, moveAmount, 0);

    }
}
