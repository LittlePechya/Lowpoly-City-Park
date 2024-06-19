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
                _dialogueText.text = "Большое спасибо, выручил! Кстати, я гляжу, ты монетки собираешь. Я видел одну за баскетбольной площадкой.";
            }
            else
            {
                int leftTrashValue = _trashController.totalTrashCount - _trashController.collectedTrashCount;
                _dialogueText.text = "Эй, парень! У меня сейчас по графику разминка, а мусор в парке сам себя не уберет. Выручишь? Осталось собрать еще где-то " + leftTrashValue + " мусора";
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