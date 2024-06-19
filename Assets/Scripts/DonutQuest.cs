using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DonutQuest : MonoBehaviour
{
    [SerializeField] private Image _questImage;
    [SerializeField] private GameObject _dialogueWindow;
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private AudioClip _questCompleteSound;

    private bool _questComplete = false;
    private bool _inDialogueZone = false;

    public bool playerHasDonut = false;

    private void Awake()
    {
        setColor(0.25f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _inDialogueZone = true;

            if (playerHasDonut)
            {
                _questComplete = true;
                setColor(1f);
                AudioSource.PlayClipAtPoint(_questCompleteSound, transform.position);
                playerHasDonut = false;
            }

            ShowDialogueWindow();
            UpdateDialogueText();


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _inDialogueZone = false;
            HideDialogueWindow();
        }
    }

    private void UpdateDialogueText()
    {
        if (_inDialogueZone)
        {
            if (_questComplete)
            {
                _dialogueText.text = "ќго, ты правда принес этот пончик дл€ мен€? —пасибо большое! Ёто как раз то, что было нужно!";
            }
            else
            {
                _dialogueText.text = "Ёх, вроде бы и хорошо на отдыхе, но € так скучаю по работе. ¬от бы было что-нибудь, что напомнило мне о моих полицейских будн€х...";
            }
        }
    }

    private void ShowDialogueWindow()
    {
        _dialogueWindow.SetActive(true);
    }

    private void HideDialogueWindow()
    {
        _dialogueWindow.SetActive(false);
    }

    private void setColor(float alphaValue)
    {
        Color imageColor = _questImage.color;
        imageColor.a = alphaValue;
        _questImage.color = imageColor;
    }
}
