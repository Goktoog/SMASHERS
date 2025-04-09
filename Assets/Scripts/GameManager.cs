using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance
    public Image[] breadIcons; // Can göstergeleri (dolu ve boş ekmek görselleri için)
    public Sprite fullBreadSprite; // Dolu ekmek görseli
    public Sprite emptyBreadSprite; // Boş ekmek görseli
    public int currentLives; // Mevcut can sayısı
    private void Awake()
    {
        // Singleton kontrolü
        if (instance == null)
        {
            instance = this; // Eğer instance yoksa bu scripti atayın
        }
        else
        {
            Destroy(gameObject); // Birden fazla GameManager varsa fazlalığı yok et
        }
    }
    void Start()
    {
        currentLives = breadIcons.Length; // Başlangıçta toplam can sayısı
        UpdateBreadIcons(); // Görsel güncellemeyi yap
    }

    // Can kaybı olduğunda çağrılan fonksiyon
    public void LoseLife()
    {
        if (currentLives > 0)
        {
            currentLives--; // Canı azalt
            UpdateBreadIcons(); // Görseli güncelle

            if (currentLives <= 0)
            {
                GameOver(); // Oyunu bitir
            }
        }
    }

    // Ekmek görsellerini güncelle
    private void UpdateBreadIcons()
    {
        for (int i = 0; i < breadIcons.Length; i++)
        {
            if (i < currentLives)
            {
                breadIcons[i].sprite = fullBreadSprite; // Dolu ekmek göster
            }
            else
            {
                breadIcons[i].sprite = emptyBreadSprite; // Boş ekmek göster
            }
        }
    }

    // Oyun bittiğinde çağrılan fonksiyon
    private void GameOver()
    {
        Debug.Log("Oyun bitti!");
        // Burada oyunu durdurabilir veya bir Game Over ekranı gösterebilirsiniz
    }
}
