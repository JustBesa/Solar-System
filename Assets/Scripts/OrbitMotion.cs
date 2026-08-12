using System.Collections;
using UnityEngine;

/// <summary>
/// Main logic and preferences
/// </summary>
public class OrbitMotion : MonoBehaviour
{
    public SolarObject solarObject;
    public OrbitRenderer orbitRenderer;

    [Range(0f, 1f)]
    public float orbitProgress = 0f;
    public bool isActive = true;

    [Range(0f, 1f)]
    public float rotationProgress = 0f;
    private Vector3 rotationDirection;

    public SpeedOptions movementSpeed;
    public SpeedOptions rotationSpeed;

    private float simulationSpeedMovementValue = 1;
    private float simulationSpeedRotationValue = 1;

    public bool enableOrbitMovement = true;
    public bool enableRotationMovement = true;
    

    public enum SpeedOptions
    {
        Normal,
       
    }

    void Start()
    {
        StartCoroutine(Movement());
        StartCoroutine(Rotation());

        rotationProgress = 0;
    }

    /// <summary>
    /// Move object along its orbit
    /// </summary>
    void SetPosition()
    {
        Vector3 position = solarObject.Evaluate(orbitProgress);
        transform.localPosition = new Vector3(position.x, 0, position.z);
    }

    private void OnValidate()
    {
        

        transform.rotation = Quaternion.Euler(solarObject.rotationAngle, 0, 0);

        // Rotate object clockwise or not
        if (solarObject.isRotationClockwise)
            rotationDirection = Vector3.up;
        else
            rotationDirection = Vector3.down;

        SetPosition();

        // Enable or disable orbit ellipse
        if (GetComponent<LineRenderer>() != null)
        {
            if (solarObject.drawOrbit)
            {
                GetComponent<LineRenderer>().enabled = true;
                orbitRenderer.CalculateEllipse(solarObject, GetComponent<LineRenderer>());
            }
            else
                GetComponent<LineRenderer>().enabled = false;
        }
    }

    /// <summary>
    /// Calculate movement position during play
    /// </summary>
    IEnumerator Movement()
    {
        while (true)
        {
            if (isActive && enableOrbitMovement && solarObject.isMoving)
            {
                float orbitSpeed = 1f / solarObject.orbitPeriodSeconds;

                orbitProgress += Time.deltaTime * orbitSpeed * simulationSpeedMovementValue;
                orbitProgress %= 1f;

                SetPosition();
            }

            yield return null;
        }
    }

    /// <summary>
    /// Calculate rotation angle during play
    /// </summary>
    IEnumerator Rotation()
    {
        while (true)
        {
            if (isActive && enableRotationMovement && solarObject.isRotating)
            {
                float rotationSpeed = 360f / solarObject.rotationPeriodSeconds;

                rotationProgress += Time.deltaTime * rotationSpeed / 360f;
                rotationProgress %= 1f;

                transform.Rotate(rotationDirection, Time.deltaTime * rotationSpeed * simulationSpeedRotationValue);
            }

            yield return null;
        }
    }
}