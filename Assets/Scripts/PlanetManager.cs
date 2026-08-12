using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlanetManager : MonoBehaviour
{
    public List<PlanetInfo> planets; // Tüm gezegenlerin listesini tutar
    public TextMeshProUGUI nameText; // UI'da gezegen adını gösterecek Text bileşeni
    public TextMeshProUGUI descriptionText; // UI'da gezegen açıklamasını gösterecek Text bileşeni
    public TextMeshProUGUI description2Text; // UI'da gezegen açıklamasını gösterecek Text bileşeni
    public TextMeshProUGUI Title1; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    public TextMeshProUGUI Data1; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    public TextMeshProUGUI Title2; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    public TextMeshProUGUI Data2; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    public TextMeshProUGUI Title3; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    public TextMeshProUGUI Data3; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    public TextMeshProUGUI Title4; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    public TextMeshProUGUI Data4; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    public TextMeshProUGUI Title5; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    public TextMeshProUGUI Data5; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    public TextMeshProUGUI Title6; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    public TextMeshProUGUI Data6; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    public TextMeshProUGUI Midddle1; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    public TextMeshProUGUI Midddle2; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    public TextMeshProUGUI Midddle3; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    public TextMeshProUGUI Midddle1Num; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    public TextMeshProUGUI Midddle2Num; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    public TextMeshProUGUI Midddle3Num; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    public TextMeshProUGUI Midddle4; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    public TextMeshProUGUI Midddle5; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    public FillBarController fillBarController1; // Reference to the FillBarController for Atmosfer
    public FillBarController fillBarController2; // Reference to the FillBarController for Atmosfer2
    public FillBarController fillBarController3; // Reference to the FillBarController for Atmosfer3


    void Start()
    {
        AssignPlanetInfo();
        
    }

    public void AssignPlanetInfo()
    {
        for (int i = 0; i < planets.Count; i++)
        {
            if (i < planets.Count)
            {
                // Her gezegen için UI bileşenlerini ayarla
                planets[i].nameText = nameText;
                planets[i].descriptionText = descriptionText;
                planets[i].description2Text = description2Text;
                planets[i].planetDataText = Data1;
                planets[i].planetData2Text = Data2;
                planets[i].planetData3Text = Data3;
                planets[i].planetData4Text = Data4;
                planets[i].planetData5Text = Data5;
                planets[i].planetData6Text = Data6;
                planets[i].planetMiddleText = Midddle1;
                planets[i].planetMiddle2Text = Midddle2;
                planets[i].planetMiddle3Text = Midddle3;
                planets[i].planetMiddle4Text = Midddle4;
                planets[i].planetMiddle5Text = Midddle5;
                planets[i].MiddleNumText = Midddle1Num;
                planets[i].Middle2NumText = Midddle2Num;
                planets[i].Middle3NumText = Midddle3Num;
                planets[i].planetTitleText = Title1;
                planets[i].planetTitle2Text = Title2;
                planets[i].planetTitle3Text = Title3;
                planets[i].planetTitle4Text = Title4;
                planets[i].planetTitle5Text = Title5;
                planets[i].planetTitle6Text = Title6;
            }

            // Bilgileri güncelle
            planets[i].UpdatePlanetInfo();

            // Update the fill bars for each atmosphere data
            fillBarController1.UpdateFillBar(planets[i].MiddleTopNum);
            fillBarController2.UpdateFillBar(planets[i].MiddleTopLeftNum);
            fillBarController3.UpdateFillBar(planets[i].MiddleTopRightNum);
        }
    }


    public void UpdateCurrentPlanetInfo(int currentIndex)
    {
        // Mevcut gezegenin bilgilerini güncelle
        if (currentIndex >= 0 && currentIndex < planets.Count)
        {
            planets[currentIndex].UpdatePlanetInfo();
            fillBarController1.UpdateFillBar(planets[currentIndex].MiddleTopNum);
            fillBarController2.UpdateFillBar(planets[currentIndex].MiddleTopLeftNum);
            fillBarController3.UpdateFillBar(planets[currentIndex].MiddleTopRightNum);
            Debug.Log($"Updated current planet info for index {currentIndex}: {planets[currentIndex].planetName}");
        }
        
    }
    
}