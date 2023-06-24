using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject prefab;
    float bound;
    public List<GameObject> Obstacles = new List<GameObject>();

    private void Start() {
        bound = GameManager.Instance.bound;
    }

    private void OnEnable() {
        for (int i = 0; i < Obstacles.Count; i++) {
            Destroy(Obstacles[i].gameObject);
        }
        Obstacles.Clear();
        Invoke(nameof(SpawnObstacle), 3f);
    }

    private void OnDisable() {
        CancelInvoke();
    }

    private void SpawnObstacle() {
        float YAxis = Random.Range(-5, -2);
        Obstacles.Add(Instantiate(prefab, new Vector3(-bound + 0.7f, YAxis, -2), Quaternion.identity));
        Invoke(nameof(SpawnObstacle), 3f);
    }

}
