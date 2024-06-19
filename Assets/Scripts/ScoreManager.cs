using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] TextMeshProUGUI textScore;
    private int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int value)
    {
        score += value;
        textScore.text = score.ToString();
    }
}
