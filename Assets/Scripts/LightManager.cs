using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightManager : MonoBehaviour
{
    [SerializeField] private GameObject _dayLight;
    [SerializeField] private GameObject _nightLight;
    [SerializeField] private Sprite _dayImage;
    [SerializeField] private Sprite _nightImage;

    [SerializeField] private Button _timeChangeButton;

    private bool _isDay = true;

    public void ChangeTime()
    {
        if (_isDay == true)
        {
            _timeChangeButton.image.sprite = _dayImage;
            _nightLight.SetActive(true);
            _dayLight.SetActive(false);
            _isDay = false;
        } else
        {
            _timeChangeButton.image.sprite = _nightImage;
            _nightLight.SetActive(false);
            _dayLight.SetActive(true);
            _isDay = true;
        }
    }
}
