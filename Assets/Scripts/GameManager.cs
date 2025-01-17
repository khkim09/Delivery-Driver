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
    [SerializeField] private bool isMinimapOpened;

    [Header("References")]
    [SerializeField] public GameObject mainCamera;
    [SerializeField] public GameObject minimapCamera;
    [SerializeField] public GameObject driver;
    [SerializeField] public RandomSpawner deliverySpawner;
    [SerializeField] public GameObject newDeliveryUI;

    void Awake()
    {
        if (GM == null)
        {
            GM = this;
        }
        if (mainCamera == null)
        {
            mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<GameObject>();
        }
        if (minimapCamera == null)
        {
            minimapCamera = GameObject.FindWithTag("MinimapCamera").GetComponent<GameObject>();
        }
    }

    void Start()
    {
        gameState = GameState.none;
    }
    
    void LateUpdate()
    {
        mainCamera.transform.position = driver.transform.position + new Vector3(0, 0, -30f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!isMinimapOpened)
            {
                minimapCamera.SetActive(true);
                isMinimapOpened = true;
            }
            else
            {
                minimapCamera.SetActive(false);
                isMinimapOpened = false;
            }
        }
        
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
