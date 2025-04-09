using UnityEngine;

public class Ant : MonoBehaviour
{
    public float speed = 3f; // Karıncanın hareket hızı
    public float rotationSpeed = 5f; // Karıncanın hedefe (ekmeğe) dönme hızı
    public Transform bread; // Ekmeğin transform'u
    private Transform target; // Karıncanın ulaşacağı hedef
    private bool isCarryingBread = false; // Karınca ekmeği taşıyor mu?

    // Hedefi yani ekmeği belirleyen bir fonksiyon
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void Update()
    {
        if (target != null)
        {
            // Hedefe doğru dön ve hareket et 
            MoveTowardsTarget();

            // Eğer hedefe ulaşıldıysa
            if (Vector3.Distance(transform.position, target.position) < 0.2f)
            {
                CarryBread(); // Ekmeği al( BURADA DÜZENLEMELER GEREK)
            }
        }

        // Dokunmayı kontrol et
        CheckTouchInput();
    }

    // Hedefe doğru dönerek hareket et (karıncanın kafasında sensörler olması)
    private void MoveTowardsTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        direction.z = 0;

        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.position += transform.up * speed * Time.deltaTime;
    }

    // Ekmeği al ve taşı (DÜZENLEMELER GEREKLİ EKMEKLER BAZEN CHILD OLDUĞUNDAN DOKUNULAMAZ OLUYOR)
    private void CarryBread()
    {
        if (!isCarryingBread)
        {
            Debug.Log("Karınca ekmeği aldı!");
            bread.SetParent(transform); // Ekmek karıncanın child'ı oldu
            bread.localPosition = new Vector3(0, -0.5f, 0);
            isCarryingBread = true;

            // Gerilim müziğini başlat
            MusicManager.instance.OnBreadCarried();
        }
    }

    // Ekmeği bırak
    private void DropBread()
    {
        if (isCarryingBread)
        {
            Debug.Log("Karınca ekmeği bıraktı!");
            bread.SetParent(null); // Ekmek bağımsız bir nesne oldu
            bread.position = transform.position + new Vector3(0, -0.5f, 0);
            isCarryingBread = false;

            // Normal müziğe geç
            MusicManager.instance.OnBreadDropped();
        }
    }

    // Dokunma girişlerini kontrol et
    void CheckTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                // Güncelleme: Raycast, karınca ya da ekmeği kontrol ediyor (raycast ile kontrol ettirdim ama çalışmıyor gibi)
                if (hit.collider != null && (hit.collider.gameObject == gameObject || hit.collider.gameObject == bread.gameObject))
                {
                    if (isCarryingBread)
                    {
                        DropBread(); // Ekmeği bırak
                    }
                    Destroy(gameObject); // Karıncayı yok et
                }
            }
        }
    }

    // Fare tıklamasını kontrol et
    void OnMouseDown()
    {
        // Güncelleme: Karınca ya da ekmeğe tıklanırsa yok et (ŞİMDİLİK CHILD SORUNUNU ÇÖZMEK İÇİN BUNU KULLANIYORUM)
        if (isCarryingBread)
        {
            DropBread();
        }
        Destroy(gameObject);
    }
}
