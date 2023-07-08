using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWindow : MonoBehaviour
{
    private TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (text != null) { text.text = ScoringManager.Instance.GetScore().ToString(); }
        else text = GetComponent<TextMeshProUGUI>();
    }
}
