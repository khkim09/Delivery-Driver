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
        }
        else if (gameState == GameState.hasCompleted)
        {
            deliverySpawner.Spawn();

            gameState = GameState.none;
        }
    }
}
