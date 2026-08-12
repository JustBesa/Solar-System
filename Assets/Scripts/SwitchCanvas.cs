using System.Collections;
using System.Collections.Generic;
using Shapes2D;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SwitchCanvas : MonoBehaviour
{
    public GameObject InfoCanvas; // Canvas for planet info
    public GameObject DetailCanvas; // Canvas for planet details
    public GameObject ButtonCanvas; // Canvas for the buttons
    public GameObject BackgroundCanvas; // Canvas for the background
    public GameObject yonButtons; // Buttons for navigation
    public GameObject Planet;
    public GameObject solarsystem;
    public GameObject splashCanvas; // Canvas for the splash screen

    public Button mainButton; // Button to switch between main menu and planets
    public Button detailButton; // Button to open detail view
    public Button PlanetButton;

    public Camera homeCamera; // Camera for the main menu view
    public Camera mainCamera; // Main camera controlled by CameraController

    public Transform homeCameraPosition; // Position and rotation for home camera

    public float transitionDelay = 0.5f; // Delay between transitions
    public float inactivityDelay = 5f; // Delay before showing splash screen

    private bool isInMainMenu = true; // Track if in the main menu
    private bool isInactive = false;
    private float lastActivityTime;
    private Vector3 lastMousePosition;
    
    private CameraController cameraController;
    //
    private PlanetManager planetManager; // Reference to PlanetManager
    private IdleManager idleManager; // IdleManager referansı


    void Start()
    {
        // Ensure all references are set
        if (InfoCanvas == null || DetailCanvas == null || ButtonCanvas == null || BackgroundCanvas == null || yonButtons == null || Planet == null || solarsystem == null || 
        mainButton == null || detailButton == null || homeCamera == null || mainCamera == null || PlanetButton == null || splashCanvas == null)
        {
            Debug.LogError("References are not set.");
            return;
        }

        cameraController = mainCamera.GetComponent<CameraController>();

        // Initially, show the main menu
        ShowMainMenu();

        splashCanvas.SetActive(false);

        lastActivityTime = Time.time;
        lastMousePosition = Input.mousePosition;

    }
    void Update()
    {
        // Eğer fare pozisyonu değiştiyse veya bir butona tıklandıysa
        if (Input.mousePosition != lastMousePosition || Input.anyKeyDown)
        {
            lastActivityTime = Time.time; // Zamanlayıcıyı sıfırla
            lastMousePosition = Input.mousePosition; // Son fare pozisyonunu güncelle
        }

        // Fare hareket etmediği sürede geçen zamanı hesapla
        float timeSinceLastMouseMove = Time.time - lastActivityTime;

        // Check for user activity (mouse movement or button clicks)
        if (timeSinceLastMouseMove <= inactivityDelay)
        {
            if (isInactive)
            {
                // Hide splash screen if activity is detected
                splashCanvas.SetActive(false);
                isInactive = false;

                ShowMainMenu();
            }
        }
        else
        {
            if (!isInactive)
            {
                splashCanvas.SetActive(true);
                isInactive = true;
            }
        }
    }

    public void OnMainButtonClick()
    {
        if (isInMainMenu)
        {
            // Switch to planet view
            ShowPlanetView();
        }
        else
        {
            // Switch back to main menu
            ShowMainMenu();
        }
    }

    public void OnDetailButtonClick()
    {
            // Open the detail view
            PlanetButton.gameObject.SetActive(false);
            DetailCanvas.gameObject.SetActive(true);
            InfoCanvas.gameObject.SetActive(false);
            BackgroundCanvas.gameObject.SetActive(true);
            yonButtons.gameObject.SetActive(false);
            Planet.gameObject.SetActive(false);

            // Disable camera control if switching to detail view from planet view
            if (cameraController != null)
            {
                cameraController.isNavigationEnabled = false;
            }

            
        
    }

    public void ShowMainMenu()
    {
        
        // Show the main menu
        PlanetButton.gameObject.SetActive(true);
        InfoCanvas.gameObject.SetActive(false);
        DetailCanvas.gameObject.SetActive(false);
        BackgroundCanvas.gameObject.SetActive(true);
        homeCamera.gameObject.SetActive(true);
        mainCamera.gameObject.SetActive(false);
        yonButtons.gameObject.SetActive(false);
        Planet.gameObject.SetActive(false);


        // Position and orient the home camera
        homeCamera.transform.position = homeCameraPosition.position;
        homeCamera.transform.rotation = homeCameraPosition.rotation;

        isInMainMenu = true;
        

        if (cameraController != null)
        {
            cameraController.isNavigationEnabled = false;
        }

    }

    public void ShowPlanetView()
    {
        // Show the planet view
        PlanetButton.gameObject.SetActive(false);
        InfoCanvas.gameObject.SetActive(true);
        BackgroundCanvas.gameObject.SetActive(true);
        homeCamera.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
        yonButtons.gameObject.SetActive(true);
        Planet.gameObject.SetActive(true);
        DetailCanvas.gameObject.SetActive(false);

        isInMainMenu = false;


        if (cameraController != null)
        {
            cameraController.isNavigationEnabled = true;
        }

    }

    public void TransitionToNextPlanet()
    {
        // Call this method when transitioning between planets
        StartCoroutine(ShowInfoWithDelay(transitionDelay));
    }

    IEnumerator ShowInfoWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        InfoCanvas.gameObject.SetActive(true); // Show info canvas after delay
    }
}
