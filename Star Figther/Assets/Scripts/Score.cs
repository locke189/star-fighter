using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] FloatVariable PlayerScore;

    TextMeshProUGUI ScoreLabel;

    void Start()
    {
        PlayerScore.value = 0;
        ScoreLabel = GetComponent<TextMeshProUGUI>();
       
    }

    
    void Update()
    {
        ScoreLabel.text = PlayerScore.value.ToString();
    }
}
