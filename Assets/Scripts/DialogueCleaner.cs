using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    private bool _inDialogueZone = false;

    [SerializeField] private GameObject _dialogueWindow;
    [SerializeField] private TextMeshProUGUI _dialogueText;

    private TrashController _trashController;

    private void Start()
    {
        _trashController = FindObjectOfType<TrashController>();
        HideDialogueWindow();
    }

    private void OnTriggerEnter(Collider other)
    {
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
            if (_trashController.questComplete)
            {
                _dialogueText.text = "������� �������, �������! ������, � �����, �� ������� ���������. � ����� ���� �� ������������� ���������.";
            }
            else
            {
                int leftTrashValue = _trashController.totalTrashCount - _trashController.collectedTrashCount;
                _dialogueText.text = "��, ������! � ���� ������ �� ������� ��������, � ����� � ����� ��� ���� �� ������. ��������? �������� ������� ��� ���-�� " + leftTrashValue + " ������";
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
}