using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float spawnRate = 1f;

    private Camera mainCamera;

    public GameObject kale;

    SkorManager skorManager;

    void Start()
    {
        mainCamera = Camera.main;

        GameObject skorObjesi = GameObject.FindWithTag("Skor");
        skorManager = skorObjesi.GetComponent<SkorManager>();


        InvokeRepeating("StartSpawn", 1.5f, spawnRate);
        InvokeRepeating("StartSpawnBottom", 2f, spawnRate);
    }


    //Top Spawner------------------------------------------------------------------------------------------
    void StartSpawn()
    {
        if (skorManager.skor >= 50 && skorManager.skor < 100)
        {
            spawnRate = 0.7f;
            CancelInvoke("StartSpawn");
            InvokeRepeating("StartSpawn", 1f, spawnRate);
        }
        else if (skorManager.skor >= 200 && skorManager.skor < 250)
        {
            spawnRate = 0.3f;
            CancelInvoke("StartSpawn");
            InvokeRepeating("StartSpawn", 0.7f, spawnRate);
        }
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
    //Top Spawner------------------------------------------------------------------------------------------



    //Bottom Spawner---------------------------------------------------------------------------------------
    void StartSpawnBottom()
    {
        if (skorManager.skor >= 50 && skorManager.skor < 100)
        {
            spawnRate = 0.7f;
            CancelInvoke("StartSpawnBottom");
            InvokeRepeating("StartSpawnBottom", 1f, spawnRate);
        }
        else if (skorManager.skor >= 200 && skorManager.skor < 250)
        {
            spawnRate = 0.3f;
            CancelInvoke("StartSpawnBottom");
            InvokeRepeating("StartSpawnBottom", 0.7f, spawnRate);
        }
        // Ekranýn yatay boyutlarýný alýn
        float horizontalSize = mainCamera.orthographicSize * mainCamera.aspect;
        // Spawn edilecek meteorun x koordinatýný belirleyin
        float spawnX = Random.Range(-horizontalSize, horizontalSize);


        Vector3 spawnPosition;
        GameObject meteor;

        SpawnMeteorBottom(spawnX, out spawnPosition, out meteor);

        MoveMeteor(spawnPosition, meteor);
    }
    private void SpawnMeteorBottom(float spawnX, out Vector3 spawnPosition, out GameObject meteor)
    {
        spawnPosition = new Vector3(spawnX, -(mainCamera.orthographicSize + 1f), 0f);
        meteor = Instantiate(meteorPrefab, spawnPosition, Quaternion.identity);
        RotateToCastle(meteor);
    }
    //Bottom Spawner---------------------------------------------------------------------------------------



    private static void MoveMeteor(Vector3 spawnPosition, GameObject meteor)
    {
        Vector3 targetPosition = Vector3.zero; // Ekranýn merkezi (kale konumu)
        Rigidbody2D rb = meteor.GetComponent<Rigidbody2D>();
        rb.velocity = (targetPosition - spawnPosition).normalized * Random.Range(2f, 5f);
    }

    private void RotateToCastle(GameObject meteor)
    {
        Vector3 direction = kale.transform.position - meteor.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        meteor.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
