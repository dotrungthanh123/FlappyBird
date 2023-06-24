using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text Score;
    public static GameManager Instance { get; private set; }
    int score;
    public Button StartButton;
    public Image OverImage;
    public Image ReadyImage;
    Bird Bird;
    Spawn Spawner;
    public float bound, bound_y;
    Animate[] bgs;

    private void Awake() {
        if (Instance != null && Instance != this) DestroyImmediate(gameObject);
        else Instance = this;
        Bird = FindObjectOfType<Bird>();
        Spawner = FindObjectOfType<Spawn>();
        bgs = FindObjectsOfType<Animate>();
        score = 0;
        bound = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
        bound_y = Camera.main.ScreenToWorldPoint(Vector3.zero).y;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && !Spawner.enabled)
            StartGame();
    }

    private void Start() {
        Spawner.enabled = false;
        Bird.GetComponent<Rigidbody2D>().isKinematic = true;
        OverImage.gameObject.SetActive(false);
    }

    public void StartGame() {
        StartButton.gameObject.SetActive(false);
        ReadyImage.gameObject.SetActive(false);
        OverImage.gameObject.SetActive(false);
        Bird.GetComponent<Rigidbody2D>().isKinematic = false;
        Bird.frame = 1;
        Bird.sign = 1;
        Bird.transform.position = Vector3.zero;
        Spawner.enabled = true;
        score = 0;
        Score.text = score.ToString();
        Obstacle.Speed = 1.5f;
        foreach (var bg in bgs) {
            bg.enabled = true;
        }
    }

    public void IncrementScore() {
        score++;
        Score.text = score.ToString();
    }

    public void GameOver() {
        StartButton.gameObject.SetActive(true);
        OverImage.gameObject.SetActive(true);
        Spawner.enabled = false;
        Obstacle.Speed = 0;
        foreach (var bg in bgs) {
            bg.enabled = false;
        }
    }
}
