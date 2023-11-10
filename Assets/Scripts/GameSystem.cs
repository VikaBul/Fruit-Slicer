using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    static GameSystem _system;

    public GameObject gameScoreCanvas;
    public GameObject endGameCanvas;
    public Text endScoreText;

    public static GameSystem System
    {
        get
        {
            if (_system == null)
            {
                _system = GameObject.FindObjectOfType<GameSystem>();

                if (_system == null)
                {
                    GameObject container = new GameObject("GameSystem");
                    _system = container.AddComponent<GameSystem>();
                }
            }
            return _system;
        }
    }

    public void OnRestart ()
    {
        endGameCanvas.SetActive(true);
        gameScoreCanvas.SetActive(false);

        SceneManager.LoadScene(0);
    }

    public void OnKnifeKill()
    {
        endScoreText.text = LEVEL.score.ToString();
        endGameCanvas.SetActive(true);
        gameScoreCanvas.SetActive(false);
    }

    public Level LEVEL;
}

[System.Serializable]
public class Level
{
    public float currentSpeed = 600;
    public int score = 0;

    public Text ScoreText;

    public void IncreaseScore()
    {
        score += 1;
        ScoreText.text = score.ToString();

        float speed = currentSpeed;
        
        if (currentSpeed != 1200)
        {
            if (score >= 200)
                speed = 900;
            if (score >= 400)
                speed = 1200;

            UpdateLevelSpeed(speed);
        }
    }

    private void UpdateLevelSpeed(float speed)
    {
        ObjectSpawner spawner = GameObject.FindObjectOfType<ObjectSpawner>();
        Animator knifeAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();

        if (speed == 900)
        {
            spawner.intervalBetweenSpawn = 0.4f;
            knifeAnimator.SetFloat("speed", 1.0f);
        }
        if (speed == 1200)
        {
            spawner.intervalBetweenSpawn = 0.25f;
            knifeAnimator.SetFloat("speed", 2.0f);
        }
        currentSpeed = speed;
    }

    public void OnVegetableCut()
    {
        IncreaseScore();
    }
}
