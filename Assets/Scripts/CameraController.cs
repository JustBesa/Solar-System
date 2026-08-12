using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public Transform[] targets; // Kamera geçiş yapacağı hedefler
    public float transitionSpeed = 2.0f; // Geçiş hızı
    public float distance = 5.0f; // Hedef objeye olan mesafe
    public float orthographicTransitionSpeed = 2.0f; // Orthographic size geçiş hızı
    public bool isNavigationEnabled = true; // Gezegenler arasında geçişin aktif olup olmadığını kontrol etmek için
    public float infoDisplayDelay = 2.0f; // Bilgi panelinin görünme gecikmesi
    public float centeringThreshold = 0.05f; // Kameranın merkezde olup olmadığını kontrol etmek için hata payı

    public GameObject delayedCanvas; // Bilgi ve başlıkların yer aldığı özel canvas
    public Button leftButton; // Sol gezinme butonu
    public Button rightButton; // Sağ gezinme butonu
    public RectTransform dragArea;

    public Transform planetsContainer; // Container holding all planets
    private List<Transform> allObjects = new List<Transform>(); // Tüm objeleri tutacak liste
    private bool isDragging = false; // Fare sürükleme kontrolü
    private Vector3 lastMousePosition; // Son fare pozisyonu
    private float dragThreshold = 15.0f; // Gezegen değiştirmek için gerekli sürükleme mesafesi
    private int currentIndex = 0; // Şu anki hedefin indeksi
    private Coroutine displayInfoCoroutine; // Bilgi paneli gösterme Coroutine'i
    private bool isCameraStable = false; // Kamera sabit mi kontrolü
    private float targetOrthographicSize;

    private Camera mainCamera;
    private PlanetInfo currentPlanetInfo; // Şu anki gezegenin bilgi scripti
    private PlanetManager planetManager; // PlanetManager referansı
    

    private Vector3 planetTargetPosition = new Vector3(0, 0, 0); // Hedef konumu (0,0,-1000)

    void Start()
    {
        mainCamera = Camera.main;
        planetManager = FindObjectOfType<PlanetManager>(); // PlanetManager referansını al
        //planetsContainer = transform;

        if (targets.Length > 0)
        {
            // Tüm objeleri listeye ekle
            foreach (Transform target in targets)
            {
                allObjects.Add(target);
            }
            UpdateCurrentPlanetInfo();
        }
        // Add button listeners
        if (leftButton != null)
            leftButton.onClick.AddListener(SwipeLeft);
        
        if (rightButton != null)
            rightButton.onClick.AddListener(SwipeRight);
            
        UpdateButtonStates();
    
    }

    void Update()
    {
        if (!isNavigationEnabled || targets.Length == 0)
            return;

        // Check if the camera is stable
        if (!isCameraStable)
        {
            // Calculate the Z-axis shift for the planetsContainer
            float zShift = -currentIndex * 10.0f;
            Vector3 targetPosition = new Vector3(-targets[currentIndex].localPosition.x, 0, zShift);
            planetsContainer.localPosition = Vector3.Lerp(planetsContainer.localPosition, targetPosition, Time.deltaTime * transitionSpeed);

            // Update the camera's orthographic size based on the planet's info
            if (mainCamera.orthographic && currentPlanetInfo != null)
            {
                targetOrthographicSize = currentPlanetInfo.orthographicSize;
                mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, targetOrthographicSize, Time.deltaTime * orthographicTransitionSpeed);
            }

            if (Vector3.Distance(planetsContainer.localPosition, targetPosition) < centeringThreshold)
            {
                isCameraStable = true;
                planetsContainer.localPosition = targetPosition; // Ensure the planet is exactly at the target position
            }
        }

        if (RectTransformUtility.RectangleContainsScreenPoint(dragArea, Input.mousePosition))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Mouse is within the drag area");
                isDragging = true;
                lastMousePosition = Input.mousePosition; 
            }

            else if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
            }

            if (isDragging)
            {
                Vector3 mouseDelta = Input.mousePosition - lastMousePosition;
                lastMousePosition = Input.mousePosition;

                if (Mathf.Abs(mouseDelta.x) > dragThreshold)
                {
                    if (mouseDelta.x > 0 && currentIndex > 0)
                    {
                        SwipeLeft();
                    }
                    else if (mouseDelta.x < 0 && currentIndex < targets.Length - 1)
                    {
                        SwipeRight();
                    }

                    UpdateCurrentPlanetInfo();
                    isCameraStable = false;
                    isDragging = false;

                    Debug.Log("Changed planet to index: " + currentIndex);
                }
            }
        }
    }

    void SwipeLeft()
    {
        if (currentIndex > 0) // Check if not on the first planet
        {
            currentIndex = (currentIndex - 1 + targets.Length) % targets.Length;
            UpdateCurrentPlanetInfo();
            isCameraStable = false;
            Debug.Log("Changed planet to index: " + currentIndex);
            UpdateButtonStates();
        }
        else
        {
            
            Debug.Log("Already on the first planet. Left swipe disabled.");
        }
    }

    void SwipeRight()
    {
        if (currentIndex < targets.Length - 1) // Check if not on the last planet
        {
            currentIndex = (currentIndex + 1) % targets.Length;
            UpdateCurrentPlanetInfo();
            isCameraStable = false;
            Debug.Log("Changed planet to index: " + currentIndex);
            UpdateButtonStates();
        }
        else
        {
            
            Debug.Log("Already on the last planet. Right swipe disabled.");
        }
    }

    void UpdateCurrentPlanetInfo()
    {
        currentPlanetInfo = targets[currentIndex].GetComponent<PlanetInfo>();
        if (currentPlanetInfo != null)
        {
            currentPlanetInfo.UpdatePlanetInfo(); // Bilgileri güncelle
            delayedCanvas.gameObject.SetActive(false);

            if (displayInfoCoroutine != null)
            {
                StopCoroutine(displayInfoCoroutine);
            }

            displayInfoCoroutine = StartCoroutine(ShowInfoWithDelay(infoDisplayDelay));
        }

        foreach (Transform obj in allObjects)
        {
            if (obj == targets[currentIndex])
            {
                obj.gameObject.SetActive(true);
            }
            else
            {
                obj.gameObject.SetActive(false);
            }
        }

        // PlanetManager'dan mevcut gezegen bilgilerini güncellemesini iste
        if (planetManager != null)
        {
            planetManager.UpdateCurrentPlanetInfo(currentIndex);
            Debug.Log($"Updated current planet info for index {currentIndex} using PlanetManager.");
        }
        else
        {
            Debug.LogError("PlanetManager reference is null.");
        }
    }

    IEnumerator ShowInfoWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (delayedCanvas != null && !delayedCanvas.activeSelf)
        {
            delayedCanvas.SetActive(true);
        }
    }
    
    void UpdateButtonStates()
    {
        // İlk gezegende soldaki butonu kapat, son gezegende sağdaki butonu kapat
        if (currentIndex == 0)
        {
            leftButton.gameObject.SetActive(false);
            rightButton.gameObject.SetActive(true);
        }
        else if (currentIndex == targets.Length - 1)
        {
            leftButton.gameObject.SetActive(true);
            rightButton.gameObject.SetActive(false);
        }
        else
        {
            leftButton.gameObject.SetActive(true);
            rightButton.gameObject.SetActive(true);
        }
    }
}