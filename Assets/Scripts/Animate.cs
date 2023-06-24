using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    public static float speed = 0.3f;
    MeshRenderer mr;

    private void Awake() {
        mr = GetComponent<MeshRenderer>();
    }

    private void Update() {
        mr.material.mainTextureOffset += Vector2.right * speed * Time.deltaTime;
    }
}
