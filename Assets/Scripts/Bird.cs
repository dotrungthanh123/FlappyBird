using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    Rigidbody2D rb;
    float JumpForce = 4f;
    [SerializeField] Sprite[] images;
    public int sign, frame;
    SpriteRenderer sr;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        frame = 1;
        sign = 1;
    }

    private void Update() {
        if (Input.GetKey(KeyCode.Space)) {
            rb.velocity = Vector2.zero;
            rb.AddForce(JumpForce * Vector2.up, ForceMode2D.Impulse);
        }
        if (transform.position.y > -GameManager.Instance.bound_y)
            transform.position = new Vector3(transform.position.x, -GameManager.Instance.bound_y + 0.25f, 0);
    }

    private void OnEnable() {
        Invoke(nameof(Animate), 0f);
        rb.isKinematic = true;
    }

    private void Animate() {
        frame += sign;
        if (frame == images.Length - 1 || frame == 0)
            sign = -sign;
        sr.sprite = images[frame];
        Invoke(nameof(Animate), 0.25f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(other.gameObject);
        GameManager.Instance.IncrementScore();
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        GameManager.Instance.GameOver();
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        sign = 0;
    }
}
