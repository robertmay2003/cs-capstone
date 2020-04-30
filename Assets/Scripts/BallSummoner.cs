using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSummoner : MonoBehaviour
{
    [Header("Balls")]
    public GameObject ball;
    public float ballLifetime;

    [Space]
    [Header("Spawning")]
    public int spawnCount;
    public float spawnDelay;

    private Camera _mainCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Spawn(spawnCount));
        }
    }

    IEnumerator Spawn(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Spawn();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void Spawn()
    {
        Vector3 position = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0;

        GameObject spawned = Instantiate(
            ball,
            position,
            Quaternion.identity
        );
        
        Destroy(spawned, ballLifetime);
    }
}
