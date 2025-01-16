using UnityEngine;

public enum GameState
{
    none,
    isDelivering,
    hasCompleted
}

public class GameManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] public static GameManager GM;
    [SerializeField] public GameState gameState;
    [SerializeField] public bool hasPackage;

    [Header("References")]
    [SerializeField] private RandomSpawner deliverySpawner;
    [SerializeField] private GameObject newDeliveryUI;

    void Awake()
    {
        if (GM == null)
        {
            GM = this;
        }
    }

    void Start()
    {
        gameState = GameState.none;
    }

    void Update()
    {
        if (gameState == GameState.none && hasPackage)
        {
            gameState = GameState.isDelivering;
        }
        else if (gameState == GameState.isDelivering && !hasPackage)
        {
            gameState = GameState.hasCompleted;
            newDeliveryUI.SetActive(true);
        }
        else if (gameState == GameState.hasCompleted && Input.GetKeyDown(KeyCode.Space))
        {
            gameState = GameState.none;
            newDeliveryUI.SetActive(false);
            
            deliverySpawner.Spawn();
        }
    }
}
