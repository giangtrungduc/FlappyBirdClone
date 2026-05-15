using NUnit.Framework;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance;
    public GameObject player;
    public GameObject pipePrefab;
    public float timeCooldown = 2f;
    private float timerCooldown;
    public bool isPlay { get; private set; }
    public bool isLoss;
    public int currentScore;
    public int highScore;
    public bool isCoin;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        timerCooldown = timeCooldown;
        if(player != null)
        {
            player.SetActive(false);
        }
        UI.Instance.OnBackBtn();
    }
    private void Update()
    {
        SpawnPipe();
    }
    public void Play()
    {
        isPlay = true;
        isLoss = false;
        currentScore = 0;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UI.Instance.SetCurrentScoreTxt(currentScore);
        UI.Instance.SetHightScoreTxt(highScore);
        if(player != null)
        {
            player.transform.position = new Vector3(0, 0, 0);
            player.SetActive(true);
        }
    }
    public void Die()
    {
        isPlay = false;
        Music.Instance.PlayDieClip();
        Invoke("Loss", 1.5f);
    }
    public void Loss()
    {
        isLoss = true;
        
        if(player != null)
        {
            player.SetActive(false);
        }
        Debug.Log("Bạn đã thua");
        UI.Instance.OnLossPanel();
    }
    public void IncreasePoint()
    {
        currentScore++;
        UI.Instance.SetCurrentScoreTxt(currentScore);
        if(currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            UI.Instance.SetHightScoreTxt(highScore);
        }
        if(currentScore % 10 == 0)
        {
            isCoin = true;
        }
    }
    private void SpawnPipe()
    {
        if(pipePrefab == null)
        {
            Debug.Log("Thiếu mẫu cột pipePrefab");
            return;
        }

        if(!isPlay) return;

        if(timerCooldown > 0)
        {
            timerCooldown -= Time.deltaTime;
            if(timerCooldown <= 0)
            {
                float x = transform.position.x;
                float y = Random.Range(-2, 4);
                float z = transform.position.z;
                Instantiate(pipePrefab, new Vector3(x, y, z), Quaternion.identity);
                timerCooldown = timeCooldown;
            }
        }
    }
}
