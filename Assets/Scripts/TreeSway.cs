using UnityEngine;

public class TreeSway : MonoBehaviour
{
    public float swayAmount = 10f; // Salınım açısı (derece)
    public float swaySpeed = 2f;  // Salınım hızı
    private float initialRotation;

    void Start()
    {
        initialRotation = transform.rotation.eulerAngles.z; // Başlangıç açısını kaydet
    }

    void Update()
    {
        // Açı hesaplama
        float angle = Mathf.Sin(Time.time * swaySpeed) * swayAmount;
        transform.rotation = Quaternion.Euler(0, 0, initialRotation + angle);
    }
}
