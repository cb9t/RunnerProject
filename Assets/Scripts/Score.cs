using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] public float score = 0f;
    [SerializeField] private TextMeshProUGUI _gameScreenScoreCounter;
    [SerializeField] private TextMeshProUGUI _deathScreenResultScore;
    [SerializeField] private TextMeshProUGUI _deathScreenRecordScore;
    [SerializeField] private UIScreens _uiScreens;

    private float _maxScore;

    private void Awake()
    {
        _uiScreens.Restart += ReloadScore;
        _uiScreens.Menu += ReloadScore;
        Health.Death += ReloadScore;
    }
    void FixedUpdate()
    {
        _gameScreenScoreCounter.text = score.ToString();
        score++;
    }
    private void ReloadScore()
    {
    
       if (score > _maxScore) _maxScore = score;
        _deathScreenRecordScore.text = _maxScore.ToString();
        _deathScreenResultScore.text = score.ToString();
        score = 0f;
    
    }
}
