using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Shapes;
public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;
    [ColorUsage(false, true)]
    [SerializeField] private Color[] colors;

    private void Awake()
    {
        score = GameObject.FindWithTag("ScoreBoard").GetComponent<TextMeshProUGUI>();
        gameObject.GetComponent<Line>().Color = colors[UnityEngine.Random.Range(0, colors.Length)];
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Line") || other.gameObject.CompareTag("Enviro"))
        {
            return;
        }
        else if(other.gameObject.CompareTag("Player"))
        {
            PlayerController.scoreValue += 1;
            score.text = (PlayerController.scoreValue).ToString();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
}
