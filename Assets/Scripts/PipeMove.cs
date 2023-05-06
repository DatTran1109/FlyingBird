using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    private float deadZone = -30;

    private void Update() {
        transform.position += Vector3.left * Time.deltaTime * moveSpeed;

        if (transform.position.x < deadZone) {
            Destroy(gameObject);
        }
    }
}
