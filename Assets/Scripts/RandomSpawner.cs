using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Vector3[] customerSpawn =
    { 
        new Vector3(-44f, -3.5f, 0f),
        new Vector3(-43.5f, -21f, 0f),
        new Vector3(-40f, -26f, 0f),        
        new Vector3(-37f, -31f, 0f),
        new Vector3(-33.46f, -22.17f, 0f),
        new Vector3(-15.18f, -16.97f, 0f),
        new Vector3(-12.35f, -12.1f, 0f),
        new Vector3(-5.18f, -7.96f, 0f),
        new Vector3(-6.69f, -12.23f, 0f),
        new Vector3(-7.74f, -26.83f, 0f),
        new Vector3(0f, -14f, 0f),
        new Vector3(4.22f, -7.46f, 0f),
        new Vector3(4.85f, 0f, 0f),
        new Vector3(-8f, 0f, 0f),
        new Vector3(-3.22f, 9.13f, 0f),
        new Vector3(-3.41f, 20.53f, 0f),
        new Vector3(2.7f, 19.32f, 0f),
        new Vector3(3.23f, 10.83f, 0f),
        new Vector3(8f, 29.22f, 0f),
        new Vector3(-29.25f, 16.08f, 0f),
        new Vector3(-25.42f, 18.91f, 0f),
        new Vector3(22.4f, 19.1f, 0f),
        new Vector3(28.29f, 16.72f, 0f),
        new Vector3(28.13f, 8.82f, 0f),
        new Vector3(20.16f, 12.59f, 0f),
        new Vector3(15.85f, -18.4f, 0f),
        new Vector3(22.87f, -18.4f, 0f),
        new Vector3(28.03f, -18.4f, 0f),
        new Vector3(27.25f, -27.7f, 0f),
        new Vector3(31.86f, -31f, 0f),
        new Vector3(36.19f, -28.8f, 0f),
        new Vector3(33.76f, -19.55f, 0f),
        new Vector3(34.05f, -10.11f, 0f),
        new Vector3(27.63f, -11f, 0f),
        new Vector3(28.02f, -5.53f, 0f),
        new Vector3(33.76f, -17.11f, 0f),
        new Vector3(39.7f, 10.51f, 0f)
    };
    [SerializeField] private int customerIndex = 0;

    void Start()
    {
        Invoke("Spawn", 0.2f);
    }
    
    void Spawn()
    {
        if (customerIndex == customerSpawn.Length)
            customerIndex = 0;
        this.transform.position = customerSpawn[customerIndex];
        customerIndex++;
        
        Invoke("Spawn", 0.2f);
    }
}
