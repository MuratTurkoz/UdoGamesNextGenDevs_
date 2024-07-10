using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance { get; private set;}

    [SerializeField] private GameObject _gameScene;
    [SerializeField] private GameObject _introScene;
    [SerializeField] private GameObject _entranceScene;

    private static int _activeScene = 0;

    private void Awake() {
        Instance = this;
        HandleScenes();
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
        HandleScenes();
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
}
