using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] public float score = 0f;
    [SerializeField] private TextMeshProUGUI _gameScreenCoinsCounter;

    

    void FixedUpdate()
    {
        _gameScreenCoinsCounter.text = score.ToString();
        score++;
    }
}
