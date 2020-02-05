using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager instance
    {
        get
        {
            if (_instance == null)
                _instance = new UIManager();

            return _instance;
        }
    }

    private float score = 0;
    public Text scoreText, statusText;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            DestroyImmediate(this);
        }
    }

    protected UIManager()
    {
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }

    public void SetScore(float value)
    {
        score = value;
        UpdateScoreText();
    }

    public void IncreaseScore(float value)
    {
        score += value;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }

    public void SetStatus(string text)
    {
        statusText.text = text;
    }



}
