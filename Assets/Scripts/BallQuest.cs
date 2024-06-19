using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BallQuest : MonoBehaviour
{
    [SerializeField] private Image _questImage;
    [SerializeField] private GameObject _dialogueWindow;
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private AudioClip _questCompleteSound;

    private bool _questComplete = false;
    private bool _inDialogueZone = false;
    private bool _questSoundPlayed = false;

    private void Start()
    {
        setColor(0.25f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            _questComplete = true;
            setColor(1f);

            if (_questSoundPlayed == false)
            {
                AudioSource.PlayClipAtPoint(_questCompleteSound, transform.position);
            }

            _questSoundPlayed = true;
        }

        if (other.CompareTag("Player"))
        {
            _inDialogueZone = true;
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
                _dialogueText.text = "�������, �������! � ������ ����� ��������! ������, �� �����, ��� ���-�� ������� ������� ����� �� ������������ ����? �� � �����!";
            }
            else
            {
                _dialogueText.text = "��, ���! �� �� ����� ��� ������� ���? �� ����� �������� �� ����� �����! � ��� ������������ ������, ��� �� ���� ����������! ������ �������� ��� ��� ����?";
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
