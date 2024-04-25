using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public TextMeshProUGUI nameScore;
    public TextMeshProUGUI ScoreText;
    public GameObject GameOverText;

    private int m_Points;

    private int highPoints;
    private string currentName;

    private bool m_Started = false;
    private bool m_GameOver = false;

    private void Awake()
    {
        if ( m_Points != 0)
        {
            ChangeScore();
        }
    }
    private void Start()
    {
        m_Points = 0;
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = UnityEngine.Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (highPoints < m_Points)
                {
                    ChangeHighScore();
                    SceneManager.LoadScene(1);
                }
                else
                {
                    SceneManager.LoadScene(1);
                }
            }
        }
    }
    private void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }

    public void GameOver()
    {
        m_GameOver = true;
    }
    public void ChangeScore()
    {
        currentName = DataManager.Instance.currentName;
        highPoints = DataManager.Instance.currentPoints;
        nameScore.text = $"Best Score : {currentName} : {highPoints}";
    }
    public void ChangeHighScore()
    {
        highPoints = m_Points;
        nameScore.text = $"Best Score: {currentName} : {highPoints}";
    }
}
