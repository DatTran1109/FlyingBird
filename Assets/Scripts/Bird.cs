using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public static Bird Instance { get; private set; }

    public event EventHandler OnPassedPipe;
    public event EventHandler OnCollidedPipe;
    public event EventHandler OnTogglePauseGame;

    private new Rigidbody2D rigidbody2D;
    private CircleCollider2D circleCollider2D;
    private float flapStrength = 20;
    private bool isBirdAlive = true;
    private bool isFlying;
    private const string TOP_PIPE = "TopPipe";
    private const string BOTTOM_PIPE = "BottomPipe";

    private void Awake() {
        Instance = this;
        rigidbody2D = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if (BirdGameManager.Instance.IsGamePlayingActive() && isBirdAlive) {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(1)) {
                rigidbody2D.velocity = Vector2.up * flapStrength;
            }

            if (Input.GetKeyDown(KeyCode.Escape)) {
                OnTogglePauseGame?.Invoke(this, EventArgs.Empty);
            }

            if (transform.position.y > 17.5 || transform.position.y < -17.5) {
                isBirdAlive = false;
                OnCollidedPipe?.Invoke(this, EventArgs.Empty);
            }

            isFlying = Input.GetKeyDown(KeyCode.Space) == true || Input.GetMouseButtonDown(1) == true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == TOP_PIPE || collision.gameObject.name == BOTTOM_PIPE) {
            circleCollider2D.isTrigger = false;
            isBirdAlive = false;
            OnCollidedPipe?.Invoke(this, EventArgs.Empty);
        }
        else {
            OnPassedPipe?.Invoke(this, EventArgs.Empty);
        }
    }

    public void SetIsBirdAlive(bool isBirdAlive) {
        this.isBirdAlive = isBirdAlive;
    }

    public bool GetIsFlying() {
        return isFlying;
    }
}
