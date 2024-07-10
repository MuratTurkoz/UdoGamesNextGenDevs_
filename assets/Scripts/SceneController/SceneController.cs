using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using DG.Tweening;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance { get; private set;}

    [SerializeField] private GameObject _gameScene;
    [SerializeField] private GameObject _introScene;
    [SerializeField] private GameObject _entranceScene;

    [SerializeField] private GameObject _sceneFadeCanvas;
    [SerializeField] private CanvasGroup _fadeCanvas;

    private static int _activeScene = 0;

    private bool _isSceneLoading;

    private void Awake() {
        Instance = this;
        HandleScenes();
    }

    private void FadeAnimation()
    {
        _fadeCanvas.alpha = 0;
        _fadeCanvas.gameObject.SetActive(true);
        _sceneFadeCanvas.gameObject.SetActive(true);
        Sequence seq = DOTween.Sequence();
        seq.Append(_fadeCanvas.DOFade(1f, 1f).OnComplete(HandleScenes));
        seq.Append(_fadeCanvas.DOFade(0f, 1.5f));
        seq.OnComplete(CloseCanvas);
    }

    private void CloseCanvas()
    {
        _sceneFadeCanvas.gameObject.SetActive(false);
    }

    public enum SceneName
    {
        EntranceScene = 0,
        IntroScene = 1,
        GameSCene = 2
    }

    public void OpenScene(SceneName sceneName)
    {
        _activeScene = (int)sceneName;
        if (_isSceneLoading) return;
        _isSceneLoading = true;
        FadeAnimation();
        Invoke(nameof(StopSceneLoading), 2.5f);
    }

    private void HandleScenes()
    {
        switch (_activeScene)
        {
            case 0:
                _gameScene.SetActive(false);
                _introScene.SetActive(false);
                _entranceScene.SetActive(true);
                break;
            case 1:
                _gameScene.SetActive(false);
                _introScene.SetActive(true);
                _entranceScene.SetActive(false);
                break;
            case 2:
                _gameScene.SetActive(true);
                _introScene.SetActive(false);
                _entranceScene.SetActive(false);
                break;
        }
    }

    private void StopSceneLoading()
    {
        _isSceneLoading = false;
    }
}
