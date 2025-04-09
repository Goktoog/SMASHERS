using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public AudioSource backgroundMusic; // Normal müzik
    public AudioSource tensionMusic; // Gerilim müziği

    private int carryingAnts = 0; // Ekmeği taşıyan karınca sayısı

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnBreadCarried()
    {
        carryingAnts++;

        if (carryingAnts == 1)
        {
            // İlk karınca ekmeği taşıyorsa gerilim müziğini başlat
            backgroundMusic.Stop();
            tensionMusic.loop = true;
            tensionMusic.Play();
        }
    }

    public void OnBreadDropped()
    {
        carryingAnts--;

        if (carryingAnts <= 0)
        {
            carryingAnts = 0;
            // Hiç karınca ekmeği taşımıyorsa normal müziğe geç
            tensionMusic.Stop();
            backgroundMusic.Play();
        }
    }

    public void ResetMusic()
    {
        carryingAnts = 0;
        tensionMusic.Stop();
        backgroundMusic.Play();
    }
}
