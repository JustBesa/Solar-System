using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to store constant values and predefined planets info
/// </summary>
public class Constants
{
    public static float SIMULATION_SPEED = 1;

    public const int SECONDS_IN_YEAR = 31536000;
    public const int SECONDS_IN_MONTH = 2592000;
    public const int SECONDS_IN_WEEK = 604800;
    public const int SECONDS_IN_DAY = 86400;

    public enum Objects
    {
        None,
        Sun,
        Mercury,
        Venus,
        Earth,
        Mars,
        Jupiter,
        Saturn,
        Uranus,
        Neptune
    }

    public static List<SolarObject> objects = new List<SolarObject> {
        new SolarObject { type = Objects.None },
        new SolarObject { type = Objects.Sun, xAxis = 0, zAxis = 0, orbitPeriodYears = 0, rotationPeriodDays = 8, rotationAngle = 7.25f, isRotationClockwise = false, isMoving = false, isRotating = true },
        new SolarObject { type = Objects.Mercury, xAxis = 10, zAxis = 15, orbitPeriodYears = 10, rotationPeriodDays = 8, rotationAngle = 2f, isRotationClockwise = false, isMoving = true, isRotating = true },
        new SolarObject { type = Objects.Venus, xAxis = 15, zAxis = 20, orbitPeriodYears = 11, rotationPeriodDays = 8, rotationAngle = 177f, isRotationClockwise = false, isMoving = true, isRotating = true },
        new SolarObject { type = Objects.Earth, xAxis = 20, zAxis = 25, orbitPeriodYears = 15, rotationPeriodDays = 8, rotationAngle = 23.5f, isRotationClockwise = false, isMoving = true, isRotating = true },
        new SolarObject { type = Objects.Mars, xAxis = 25, zAxis = 30, orbitPeriodYears = 40, rotationPeriodDays = 8, rotationAngle = 25f, isRotationClockwise = false, isMoving = true, isRotating = true },
        new SolarObject { type = Objects.Jupiter, xAxis = 30, zAxis = 35, orbitPeriodYears = 47, rotationPeriodDays = 8, rotationAngle = 3f, isRotationClockwise = false, isMoving = true, isRotating = true },
        new SolarObject { type = Objects.Saturn, xAxis = 35, zAxis = 40, orbitPeriodYears = 45, rotationPeriodDays = 8, rotationAngle = 26f, isRotationClockwise = false, isMoving = true, isRotating = true },
        new SolarObject { type = Objects.Uranus, xAxis = 40, zAxis = 45, orbitPeriodYears = 48, rotationPeriodDays = 8, rotationAngle = 97f, isRotationClockwise = false, isMoving = true, isRotating = true },
        new SolarObject { type = Objects.Neptune, xAxis = 45, zAxis = 50, orbitPeriodYears = 90, rotationPeriodDays = 8, rotationAngle = 29.6f, isRotationClockwise = false, isMoving = true, isRotating = true },
    };

    /// <summary>
    /// Return selected planet info
    /// </summary>
    public static SolarObject GetObjectData(Objects selected)
    {
        return objects.Find(x => x.type == selected);
    }

    
}