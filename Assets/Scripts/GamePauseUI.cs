using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;

    private void Start() {
        gameObject.SetActive(false);

        BirdGameManager.Instance.OnGamePaused += BirdGameManager_OnGamePaused;
        BirdGameManager.Instance.OnGameUnpaused += BirdGameManager_OnGameUnpaused;

        resumeButton.onClick.AddListener(() => {
            BirdGameManager.Instance.TogglePauseGame();
        });

        mainMenuButton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.MainMenuScene);
        });
    }

    private void BirdGameManager_OnGameUnpaused(object sender, System.EventArgs e) {
        gameObject.SetActive(false);
    }

    private void BirdGameManager_OnGamePaused(object sender, System.EventArgs e) {
        gameObject.SetActive(true);
    }
}
