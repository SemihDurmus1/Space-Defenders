using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float spawnRate = 2f;

    private Camera mainCamera;

    public GameObject kale;

    void Start()
    {
        mainCamera = Camera.main;
        InvokeRepeating("StartSpawn", 1.5f, spawnRate);
    }

    void StartSpawn()
    {
        // Ekranýn yatay boyutlarýný alýn
        float horizontalSize = mainCamera.orthographicSize * mainCamera.aspect;
        // Spawn edilecek meteorun x koordinatýný belirleyin
        float spawnX = Random.Range(-horizontalSize, horizontalSize);


        Vector3 spawnPosition;
        GameObject meteor;

        SpawnMeteor(spawnX, out spawnPosition, out meteor);

        MoveMeteor(spawnPosition, meteor);
    }

    private void SpawnMeteor(float spawnX, out Vector3 spawnPosition, out GameObject meteor)
    {
        spawnPosition = new Vector3(spawnX, mainCamera.orthographicSize + 1f, 0f);
        meteor = Instantiate(meteorPrefab, spawnPosition, Quaternion.identity);
        RotateToCastle(meteor);
    }

    private static void MoveMeteor(Vector3 spawnPosition, GameObject meteor)
    {
        Vector3 targetPosition = Vector3.zero; // Ekranýn merkezi (kale konumu)
        Rigidbody2D rb = meteor.GetComponent<Rigidbody2D>();
        rb.velocity = (targetPosition - spawnPosition).normalized * Random.Range(3f, 8f);
    }

    private void RotateToCastle(GameObject meteor)
    {
        Vector3 direction = kale.transform.position - meteor.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        meteor.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
