using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroEnding : MonoBehaviour
{
    [SerializeField] private float _automaticEndingTime = 25;
    [SerializeField] private float _showSkipBtnTime = 5;
    private float _timer;
    private bool _isSceneEnded;

    [SerializeField] private GameObject _skipIntroPanel;
    [SerializeField] private Button _skipBtn;

    private void Awake() {
        _skipBtn.onClick.AddListener(EndScene);
    }

    private void Update() {
        _timer += Time.deltaTime;
        if (_timer >= _automaticEndingTime)
        {
            EndScene();
        }
        if (_timer >= _showSkipBtnTime)
        {
            if (_isSceneEnded) return;
            _skipIntroPanel.SetActive(true);
        }
    }

    private void EndScene()
    {
        if (_isSceneEnded) return;

        _isSceneEnded = true;
        _skipIntroPanel.SetActive(false);
        SceneController.Instance.OpenScene(SceneController.SceneName.GameSCene);
    }

}
