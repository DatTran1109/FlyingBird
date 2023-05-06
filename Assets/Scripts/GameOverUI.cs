using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI recordText;
    [SerializeField] private Button replayButton;
    [SerializeField] private Button mainMenuButton;

    private void Start()
    {
        gameObject.SetActive(false);

        BirdGameManager.Instance.OnStateChanged += BirdGameManager_OnStateChanged;

        replayButton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.GameScene);
        });

        mainMenuButton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.MainMenuScene);
        });
    }

    private void BirdGameManager_OnStateChanged(object sender, System.EventArgs e) {
        if (BirdGameManager.Instance.IsGameOverActive()) {
            scoreText.text = "Your Score: " + BirdGameManager.Instance.GetScore().ToString();
            recordText.text = "Highest Score: " + BirdGameManager.Instance.GetRecord().ToString();
            gameObject.SetActive(true);
        }
    }
}
