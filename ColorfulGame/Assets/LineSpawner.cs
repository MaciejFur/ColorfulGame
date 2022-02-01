using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSpawner : MonoBehaviour
{
    [SerializeField] private GameObject linePrefab;
    [SerializeField] private float xMax;
    [SerializeField] private float speed = .1f;

    private bool _gameActive;
    void Start()
    {
        _gameActive = true;
        StartCoroutine(SpawnLine());
    }

    private IEnumerator SpawnLine()
    {
        while (_gameActive)
        {
            yield return new WaitForSeconds(speed);
            Instantiate(
                linePrefab,
                new Vector2(transform.position.x + Mathf.Clamp(Random.Range(0f, 10f), 0, xMax), transform.position.y),
                Quaternion.identity);   
        }
    }
}
