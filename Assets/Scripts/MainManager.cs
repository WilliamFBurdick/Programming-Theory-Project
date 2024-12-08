using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }
    public bool GameInProgress { get; private set; }

    [SerializeField] private float spawnRate = 1.0f;
    [SerializeField] Obstacle[] obstacles;
    [SerializeField] Transform spawnPoint;

    [SerializeField] GameObject gameOverUI;

    private int m_PlayerScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        GameStart();
    }

    public void GameStart()
    {
        GameInProgress = true;
        InvokeRepeating("SpawnObstacle", spawnRate, spawnRate);
    }

    public void GameOver()
    {
        GameInProgress = false;
        CancelInvoke("SpawnObstacle");
        gameOverUI.SetActive(true);
    }

    private void SpawnObstacle()
    {
        Obstacle randomObstacle = obstacles[Random.Range(0, obstacles.Length)];
        float spawnX = Random.Range(-1.5f, 1.5f);
        Vector3 spawnPos = new Vector3(spawnX, spawnPoint.position.y, spawnPoint.position.z);

        Instantiate(randomObstacle, spawnPos, randomObstacle.transform.rotation);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
