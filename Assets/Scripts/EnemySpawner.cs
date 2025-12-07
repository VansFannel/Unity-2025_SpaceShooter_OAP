using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public enum SpawnMode
    {
        Line,
        Points
    }

    [SerializeField]
    SpawnMode spawnMode;

    [SerializeField]
    GameObject enemyPrefab;

    [SerializeField]
    Transform spawnLineTop;
    
    [SerializeField]
    Transform spawnLineBottom;

    [SerializeField]
    Transform[] spawnPoints;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (spawnMode == SpawnMode.Line)
        {
            StartCoroutine(LineSpawning());
            //SpawnWithLineTopAndDown();
        }
        else if (spawnMode == SpawnMode.Points)
        {
            SpawnWithPoints();
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator LineSpawning()
    {
        Vector3 lineTop = spawnLineTop.position;
        Vector3 lineBottom = spawnLineBottom.position;

        for (int i = 0; i < 5; i++)
        {
            Vector3 startPosition = Vector3.Lerp(lineTop, lineBottom, Random.Range(.0f, 1.0f));
            Instantiate(enemyPrefab, startPosition, Quaternion.identity);

            yield return new WaitForSeconds(0.5f);
        }

    }


    private void SpawnWithLineTopAndDown()
    {
        Vector3 lineTop = spawnLineTop.position;
        Vector3 lineBottom = spawnLineBottom.position;

        for (int i = 0; i < 5; i++)
        {
            Vector3 startPosition = Vector3.Lerp(lineTop, lineBottom, Random.Range(.0f, 1.0f));
            Instantiate(enemyPrefab, startPosition, Quaternion.identity);
        }
    }

    private void SpawnWithPoints()
    {
        int numPoints = spawnPoints.Length;

        for (int i = 0; i < numPoints; i++)
        {
            Vector3 startPosition = spawnPoints[Random.Range(0, numPoints)].position;
            Instantiate(enemyPrefab, startPosition, Quaternion.identity);
        }
    }
}
