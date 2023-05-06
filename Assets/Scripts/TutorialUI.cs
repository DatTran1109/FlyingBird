using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    private void Start() {
        BirdGameManager.Instance.OnStateChanged += BirdGameManager_OnStateChanged;
    }

    private void BirdGameManager_OnStateChanged(object sender, System.EventArgs e) {
        if (BirdGameManager.Instance.IsWaitingActive()) {
            gameObject.SetActive(true);
        }
        else {
            gameObject.SetActive(false);
        }
    }
}
