using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntranceManager : MonoBehaviour
{
    [SerializeField] private Button _startBtn;
    private const string IS_INTRO_SHOWED_KEY = "isIntroShowed";

    private void Awake() {
        _startBtn.onClick.AddListener(OnStartPressed);
    }

    private void OnStartPressed()
    {
        SoundManager.Instance.PlayUiBtn();
        if (PlayerPrefs.GetInt(IS_INTRO_SHOWED_KEY, 0) == 0)
        {
            PlayerPrefs.SetInt(IS_INTRO_SHOWED_KEY, 1);
            SceneController.Instance.OpenScene(SceneController.SceneName.IntroScene);
        }
        else
        {
            SceneController.Instance.OpenScene(SceneController.SceneName.GameSCene);
        }
    }
}
