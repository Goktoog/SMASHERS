using UnityEngine;

public class Bread : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Boundary")) // Boundary sahnenin sınırı olmalı
        {
            GameManager.instance.LoseLife(); // Canı azalt

            // Eğer can kalmamışsa ekmek yeniden doğmasın
            if (GameManager.instance.currentLives > 0) 
            {
                RespawnBread(); // Yeni ekmek oluştur
            }
                    //RespawnBread(); // Yeni ekmek oluştur

            MusicManager.instance.ResetMusic(); // Müziği sıfırla
        }
    }

    // Yeni ekmeği oluşturma
    private void RespawnBread()
    {
        transform.position = Vector3.zero; // Başlangıç konumuna taşı (veya istediğiniz başka bir yer)
    }
}
