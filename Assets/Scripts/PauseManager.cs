using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private AudioSource _backgroundMusic;

    public bool isPaused = false;
    private bool musicIsPlaying = true;
    private bool _isCursorVisible = false;

    void Awake()
    {
        _pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        if (isPaused)
        {
            isPaused = false;
            _pauseMenu.SetActive(false);
            _isCursorVisible = false;
        } else
        {
            isPaused = true;
            _pauseMenu.SetActive(true);
            _isCursorVisible = true;
        }

        UpdateCursorVisibility();
    }

    void UpdateCursorVisibility()
    {
        Cursor.visible = _isCursorVisible;

        if (_isCursorVisible)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void ClosePauseMenuByButton()
    {
        isPaused = false;
        _pauseMenu.SetActive(false);
        _isCursorVisible = false;
    }

    public void QuitGame()
    {
        Debug.Log("quit!");
        Application.Quit();
    }

    public void ToggleMusic()
    {
        if (musicIsPlaying)
        {
            _backgroundMusic.mute = true;
            musicIsPlaying = false;
        } else
        {
            _backgroundMusic.mute = false;
            musicIsPlaying = true;
        }
    }

}
