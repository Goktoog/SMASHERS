using UnityEngine;

public class Bread : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Boundary")) // Boundary sahnenin sınırı karıncalar istrigger bölgesinden caan eksilsin diye.
        {
            GameManager.instance.LoseLife(); // Canı azalt

            // Eğer can kalmamışsa ekmek yeniden doğmasın
            if (GameManager.instance.currentLives > 0) 
            {
                RespawnBread(); // Yeni ekmek oluştur
            }

            MusicManager.instance.ResetMusic(); // Müziği sıfırla (Burada bir hata meydana geliyor bu yüzden her can bittiğinde müziği sıfırlayıp default müziğe dönüyorum.)
        }
    }

    // Yeni ekmeği oluşturma
    private void RespawnBread()
    {
        transform.position = Vector3.zero; // Başlangıç konumuna taşı default ekmek transform bölgesinde respawn için.
    }
}
