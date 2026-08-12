using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IdleManager : MonoBehaviour
{
    public GameObject splashCanvas; // Splash ekranını referans edin
    public float idleTimeThreshold = 10f; // Hareketsizlik süresi eşiği (saniye cinsinden)

    private float lastActivityTime; // Son etkileşim zamanı

    void Start()
    {
        lastActivityTime = Time.time;
        splashCanvas.SetActive(false);
    }

    void Update()
    {
        // Kullanıcı etkileşimini kontrol et (fare hareketi ve tuş basımı)
        if (Input.anyKeyDown || Input.mousePosition != Vector3.zero)
        {
            lastActivityTime = Time.time; // Son etkileşim zamanını güncelle
            splashCanvas.SetActive(false);
        }
        else
        {
            // Hareketsizlik süresi eşiğini kontrol et
            if (Time.time - lastActivityTime > idleTimeThreshold)
            {
                // Hareketsizlik süresi aşıldı, splash ekranını göster
                splashCanvas.SetActive(true);
            }
        }
    }
}
