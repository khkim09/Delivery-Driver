using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

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
    [SerializeField] public int lives = 3;

    [Header("References")]
    [SerializeField] public GameObject mainCamera;
    [SerializeField] public GameObject minimapCamera;
    [SerializeField] private GameObject driver;
    [SerializeField] private RandomSpawner deliverySpawner;
    [SerializeField] private GameObject deliveryStartUI;
    [SerializeField] private GameObject deliveringUI;
    [SerializeField] private GameObject deliveryCompletedUI;
    [SerializeField] private GameObject deliveryFailedUI;

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

    void UIDisable()
    {
        deliveryStartUI.SetActive(false);
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

        void CheckRestart()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("main");
                deliveryFailedUI.SetActive(false);
            }
        }
        
        if (gameState == GameState.none && hasPackage)
        {
            gameState = GameState.isDelivering;
            deliveryStartUI.SetActive(true);
            Invoke("UIDisable", 1.0f);
            deliveringUI.SetActive(true);
        }
        else if (gameState == GameState.isDelivering && lives <= 0)
        {
            gameState = GameState.none;
            deliveryFailedUI.SetActive(true);
            CheckRestart();
        }
        else if (gameState == GameState.isDelivering && !hasPackage)
        {
            gameState = GameState.hasCompleted;
            deliveringUI.SetActive(false);
            deliveryCompletedUI.SetActive(true);
            lives = 3;
        }
        else if (gameState == GameState.hasCompleted && Input.GetKeyDown(KeyCode.Space))
        {
            gameState = GameState.none;
            deliveryCompletedUI.SetActive(false);

            deliverySpawner.Spawn();
        }
    }
}
