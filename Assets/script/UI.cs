using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text score;
    public Text finalScore;
    public GameObject gameOver;
    public GameObject nextLevel;

    public void Score(string scoreText)
    {
        score.text = "x"+scoreText;
        finalScore.text = "Score: "+ scoreText;
    }
    public void ShowGameOver(bool isGameOver)
    {
        gameOver.SetActive(isGameOver);
    }
    public void ShowNextLevel(bool isNextLevel)
    {
        nextLevel.SetActive(isNextLevel);
    }
}