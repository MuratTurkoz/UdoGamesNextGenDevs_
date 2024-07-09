using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// EMİRCAN

public class InGameUI : MonoBehaviour
{
    [SerializeField] private Int _currentExp, _targetExp, _playerLevel;

    [Header("Panels")]
    [SerializeField] private GameObject _inGamePanel;
    [SerializeField] private GameObject _upgradePanel;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _endGamePanel;

    [Header("In Game Panel")]
    [SerializeField] private Button _pauseBtn;
    [SerializeField] private Image _expBarImage;
    [SerializeField] private TextMeshProUGUI _lvlTMP;
    [SerializeField] private TextMeshProUGUI _scoreTMP;

    [Header("Pause Panel")]
    [SerializeField] private Button _continueBtn;

    private void Awake()
    {
        _inGamePanel.SetActive(true);
        _upgradePanel.SetActive(false);
        _pauseBtn.onClick.AddListener(OnPauseBtnClicked);

        _expBarImage.fillAmount = 0;
        _lvlTMP.SetText("0");
        _scoreTMP.SetText("0");

        UpgradeBtn.OnUpgradeSelected += CloseUpgradePanel;
        // ON LEVEL UP SHOW UPGRADE PANEL

        _currentExp.OnValueChanged += OnExpGained;
        _playerLevel.OnValueChanged += OnLevelUp;

        _continueBtn.onClick.AddListener(OnContinueBtnPressed);
    }

    private void OnContinueBtnPressed()
    {
        ClosePausePanel();
    }

    private void OnLevelUp(int level)
    {
        _lvlTMP.SetText(level.ToString());
        _expBarImage.fillAmount = 0;

        if (level != 0) ShowUpgradePanel();
    }

    public void ShowEndGame()
    {
        _endGamePanel.SetActive(true);
    }

    private void ShowUpgradePanel()
    {
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
    }

    private void CloseUpgradePanel()
    {
        _upgradePanel.SetActive(false);
        Time.timeScale = 1;
    }

    private void OnPauseBtnClicked()
    {
        _pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void ClosePausePanel()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
