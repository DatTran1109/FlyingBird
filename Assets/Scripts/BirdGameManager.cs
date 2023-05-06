using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BirdGameManager : MonoBehaviour
{
    public enum State {
        Waiting,
        GamePlaying,
        GameOver,
    }
    private State state;

    public static BirdGameManager Instance { get; private set; }

    public event EventHandler OnStateChanged;
    public event EventHandler OnGamePaused;
    public event EventHandler OnGameUnpaused;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI recordText;

    private int score = 0;
    private int record = 0;
    private const string RECORD = "Record";
    private bool isGamePaused = false;

    private void Awake() {
        Instance = this;
        state = State.Waiting;
    }

    private void Start()
    {
        Bird.Instance.OnPassedPipe += Bird_OnPassedPipe;
        Bird.Instance.OnCollidedPipe += Bird_OnCollidedPipe;
        Bird.Instance.OnTogglePauseGame += Bird_OnTogglePauseGame;

        record = PlayerPrefs.GetInt(RECORD, 0);
        recordText.text = "Highest Score: " + record.ToString();
    }

    private void Update() {
        switch (state) {
            case State.Waiting:
                Time.timeScale = 0f;
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(1)) {
                    Time.timeScale = 1f;
                    state = State.GamePlaying;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
             
                break;
            case State.GamePlaying:

                break;
            case State.GameOver:

                break;
        }
    }

    private void Bird_OnCollidedPipe(object sender, EventArgs e) {
        if (score > record) {
            SaveNewRecord(score);
        }

        state = State.GameOver;
        OnStateChanged?.Invoke(this, EventArgs.Empty);
    }

    private void Bird_OnTogglePauseGame(object sender, System.EventArgs e) {
        TogglePauseGame();
    }

    private void Bird_OnPassedPipe(object sender, System.EventArgs e) {
        score ++;
        scoreText.text = "Your Score: " + score.ToString();
    }

    public bool IsGamePlayingActive() {
        return state == State.GamePlaying;
    }

    public bool IsGameOverActive() {
        return state == State.GameOver;
    }

    public bool IsWaitingActive() {
        return state == State.Waiting;
    }

    public int GetScore() {
        return score;
    }

    public int GetRecord() {
        return record;
    }

    private void SaveNewRecord(int score) {
        PlayerPrefs.SetInt(RECORD, score);
        PlayerPrefs.Save();
    }

    public void TogglePauseGame() {
        isGamePaused = !isGamePaused;

        if (isGamePaused) {
            Time.timeScale = 0f;
            OnGamePaused?.Invoke(this, EventArgs.Empty);

        }
        else {
            Time.timeScale = 1f;
            OnGameUnpaused?.Invoke(this, EventArgs.Empty);
        }
    }
}
