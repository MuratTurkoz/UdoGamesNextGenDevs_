using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    private AudioSource _audioSource;
    private Transform _mainCamera;

    private void Awake() {
        Instance = this;
        _audioSource = GetComponent<AudioSource>();
        _mainCamera = Camera.main.transform;
    }

    [SerializeField] private AudioClip[] _uiBtnClips;
    [SerializeField] private AudioClip _onUpgradeSelected;
    [SerializeField] private AudioClip _arrowWhoosh;

    public void PlayUiBtn()
    {
        AudioSource.PlayClipAtPoint(_uiBtnClips[Random.Range(0, _uiBtnClips.Length)], _mainCamera.position);
    }

    public void PlayUpgradeSelected()
    {
        AudioSource.PlayClipAtPoint(_onUpgradeSelected, _mainCamera.position);
    }

    public void PlayArrowWhoosh()
    {
        AudioSource.PlayClipAtPoint(_arrowWhoosh, _mainCamera.position, 0.1f);
    }
}
