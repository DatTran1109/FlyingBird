using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private Transform pipe;
    private float spawnRate = 0;
    private float timer = 0;
    private float heightOffset = 7;

    private void Update() {
        if (timer <= spawnRate) {
            timer = timer + Time.deltaTime;
        }
        else {
            spawnPipe();
            timer = 0;
            spawnRate = Random.Range(3, 6);
        }
    }

    void spawnPipe() {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
