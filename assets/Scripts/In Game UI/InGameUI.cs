using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject _inGamePanel;
    [SerializeField] private GameObject _upgradePanel;
    [SerializeField] private GameObject _pausePanel;

    [Header("In Game Panel")]
    [SerializeField] private Button _pauseBtn;
    [SerializeField] private Image _expBarImage;
    [SerializeField] private TextMeshProUGUI _lvlTMP;
    [SerializeField] private TextMeshProUGUI _scoreTMP;

    private void Awake() {
        _inGamePanel.SetActive(true);
        _upgradePanel.SetActive(false);
        _pauseBtn.onClick.AddListener(OnPauseBtnClicked);

        _expBarImage.fillAmount = 0;
        _lvlTMP.SetText("0");
        _scoreTMP.SetText("0");

        UpgradeBtn.OnUpgradeSelected += CloseUpgradePanel;
        // ON LEVEL UP SHOW UPGRADE PANEL
    }

    private void OnDestroy() {
        UpgradeBtn.OnUpgradeSelected -= CloseUpgradePanel;
    }

    private void CloseUpgradePanel()
    {
        _upgradePanel.SetActive(false);
    }

    private void OnPauseBtnClicked()
    {
        _pausePanel.SetActive(true);
        Time.timeScale = 0;
    }
}
