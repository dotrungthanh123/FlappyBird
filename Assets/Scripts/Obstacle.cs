using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public static float Speed;

    private void Update() {
        if (transform.position.x < GameManager.Instance.bound - 0.6) {
            Destroy(gameObject);
        }
        transform.position += Vector3.left * Speed * Time.deltaTime;
    }
}
