using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// EMİRCAN

public class InGameUI : MonoBehaviour
{
    [SerializeField] private Int _currentExp, _targetExp, _playerLevel, _playerScore;

    [Header("Panels")]
    [SerializeField] private GameObject _inGamePanel;
    [SerializeField] private GameObject _upgradePanel;
    [SerializeField] private GameObject upgradeManager;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _endGamePanel;

    [Header("In Game Panel")]
    [SerializeField] private Button _pauseBtn;
    [SerializeField] private Image _expBarImage;
    [SerializeField] private TextMeshProUGUI _lvlTMP;
    [SerializeField] private TextMeshProUGUI _scoreTMP;

    [Header("Pause Panel")]
    [SerializeField] private Button _continueBtn;

    [Header("Game Over Panel")]
    [SerializeField] private Button _restartBtn;
    [SerializeField] private TextMeshProUGUI _endScoreTMP;
    [SerializeField] private TextMeshProUGUI _highScoreTMP;

    private void Awake()
    {
        _inGamePanel.SetActive(true);
        _upgradePanel.SetActive(false);
        _pauseBtn.onClick.AddListener(OnPauseBtnClicked);

        _expBarImage.fillAmount = 0;
        _lvlTMP.SetText("1");
        _scoreTMP.SetText("0");

        UpgradeBtn.OnUpgradeSelected += CloseUpgradePanel;
        // ON LEVEL UP SHOW UPGRADE PANEL

        _currentExp.OnValueChanged += OnExpGained;
        _playerLevel.OnValueChanged += OnLevelUp;

        _continueBtn.onClick.AddListener(OnContinueBtnPressed);

        _restartBtn.onClick.AddListener(OnRestartBtnPressed);

        _playerScore.OnValueChanged += OnScoreUpdated;
    }
    // comment line
    private void OnScoreUpdated(int score)
    {
        _scoreTMP.SetText(score.ToString());
    }

    private void OnRestartBtnPressed()
    {
        SoundManager.Instance.PlayUiBtn();
        GameManager.Instance.RestartGame();
    }

    private void OnContinueBtnPressed()
    {
        ClosePausePanel();
        SoundManager.Instance.PlayUiBtn();
    }

    private void OnLevelUp(int level)
    {
        _lvlTMP.SetText((level + 1).ToString());
        _expBarImage.fillAmount = 0;

        if (level != 0) ShowUpgradePanel();
    }

    public void ShowEndGame()
    {
        _endScoreTMP.SetText("Score: " + _playerScore.Value);
        int highScore = Mathf.Max(_playerScore.Value, PlayerPrefs.GetInt("highScore", 0));
        _highScoreTMP.SetText("High Score: " + highScore);
        PlayerPrefs.SetInt("highScore", highScore);

        _endGamePanel.SetActive(true);
    }

    private void ShowUpgradePanel()
    {
        SoundManager.Instance.PlayUpgradeSelected();
        upgradeManager.GetComponent<UpgradeManager>().PrepareUpgradePanel();
        _upgradePanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnExpGained(int exp)
    {
        _expBarImage.fillAmount = (float)exp / _targetExp;
    }

    private void OnDestroy()
    {
        UpgradeBtn.OnUpgradeSelected -= CloseUpgradePanel;
        _currentExp.OnValueChanged -= OnExpGained;
        _playerLevel.OnValueChanged -= OnLevelUp;
        _playerScore.OnValueChanged -= OnScoreUpdated;
    }

    private void CloseUpgradePanel()
    {
        _upgradePanel.SetActive(false);
        Time.timeScale = 1;
        SoundManager.Instance.PlayUiBtn();
    }

    private void OnPauseBtnClicked()
    {
        SoundManager.Instance.PlayUiBtn();
        _pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void ClosePausePanel()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
