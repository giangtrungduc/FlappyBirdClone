using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI Instance;
    [Header("Start")]
    public GameObject startPanel;
    public Sprite uiopenSprite;
    public Sprite uiclossSprite;
    public Button musicBtn;
    public Button playBtn;
    [Header("Playing")]
    public GameObject playPanel;
    public TextMeshProUGUI currentScoreTxt;
    public TextMeshProUGUI hightScoreTxt;
    [Header("Loss")]
    public GameObject lossPanel;
    public TextMeshProUGUI currentScoreLossTxt;
    public TextMeshProUGUI hightScoreLossTxt;
    public Button backBtn;

    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    private void Start()
    {
        if(musicBtn != null) musicBtn.onClick.AddListener(OnMusicBtn);
        if(playBtn != null) playBtn.onClick.AddListener(OnPlayBtn);
        if(backBtn != null) backBtn.onClick.AddListener(OnBackBtn);
    }
    public void OnMusicBtn()
    {
        Music.Instance.SetVolume();
        musicBtn.gameObject.GetComponent<Image>().sprite = Music.Instance.isToggle ? uiopenSprite : uiclossSprite;
    }
    public void OnPlayBtn()
    {
        SetPanel(false, true, false);
        Manager.Instance.Play();
    }
    public void OnBackBtn()
    {
        SetPanel(true, false, false);
    }
    public void SetCurrentScoreTxt(int score)
    {
        if(currentScoreTxt != null) currentScoreTxt.text = "" + score;
        if(currentScoreLossTxt != null) currentScoreLossTxt.text = "" + score;
    }
    public void SetHightScoreTxt(int score)
    {
        if(hightScoreTxt != null) hightScoreTxt.text = "" + score;
        if(hightScoreLossTxt != null) hightScoreLossTxt.text = "" + score;
    }
    public void OnLossPanel()
    {
        SetPanel(false, false, true);
    }
    private void SetPanel(bool p1, bool p2, bool p3)
    {
        if(startPanel == null || playPanel == null || lossPanel == null) return;

        startPanel.SetActive(p1);
        playPanel.SetActive(p2);
        lossPanel.SetActive(p3);
    }
}
