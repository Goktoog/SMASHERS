using UnityEngine;

public class AntSpawner : MonoBehaviour
{
    public GameObject antPrefab; // Karınca prefab'ini buraya ekleyin
    public Transform target; // Hedef (örn. ekmek)
    public float spawnInterval = 2f; // Karıncaların spawn olma süresi
    public float spawnHeightOffset = 15f; // Spawner’ın hedefin üzerinde ne kadar yukarıda olacağı

    private void Start()
    {
        // Belirli bir aralıkla karınca üret
        InvokeRepeating(nameof(SpawnAnt), 0f, spawnInterval);
    }

    void SpawnAnt()
    {
        // Spawner pozisyonunu hedefin üstünde belirle
        Vector3 spawnPosition = new Vector3(
            target.position.x, // Hedefin X pozisyonu
            target.position.y + spawnHeightOffset, // Hedefin Y pozisyonunun üstü
            0 // 2D için Z ekseni 0 olmalı
        );

        // Yeni karınca oluştur
        GameObject newAnt = Instantiate(antPrefab, spawnPosition, Quaternion.identity);

        // Karıncanın hedefini ayarla
        Ant antScript = newAnt.GetComponent<Ant>();
        if (antScript != null && target != null)
        {
            antScript.SetTarget(target);
        }
    }
}
