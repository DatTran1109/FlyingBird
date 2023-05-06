using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
    private float loadingTimer = 1f;

    private void Update() {
        loadingTimer -= Time.deltaTime;

        if (loadingTimer < 0f) {
            Loader.LoaderCallback();
        }
    }
}
