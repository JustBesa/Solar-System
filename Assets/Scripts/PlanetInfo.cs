using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Experimental.GlobalIllumination;

public class PlanetInfo : MonoBehaviour
{
    public string planetName; // Gezegen adı
    public string planetDescription; // Gezegen açıklaması
    public string KesifGozlem ; // Gezegen açıklaması
    public string Title; // Gezegen sayısal verileri
    public string Data1; // Gezegen sayısal verileri
    public string Title2; // Gezegen sayısal verileri
    public string Data2; // Gezegen sayısal verileri
    public string Title3; // Gezegen sayısal verileri
    public string Data3; // Gezegen sayısal verileri
    public string Title4; // Gezegen sayısal verileri
    public string Data4; // Gezegen sayısal verileri
    public string Title5; // Gezegen sayısal verileri
    public string Data5; // Gezegen sayısal verileri
    public string Title6; // Gezegen sayısal verileri
    public string Data6; // Gezegen sayısal verileri
    public string MiddleTop; // Gezegen sayısal verileri
    public float MiddleTopNum; // Gezegen sayısal verileri
    public string MiddleTopLeft; // Gezegen sayısal verileri
    public float MiddleTopLeftNum; // Gezegen sayısal verileri
    public string MiddleTopRight; // Gezegen sayısal verileri
    public float MiddleTopRightNum; // Gezegen sayısal verileri
    public string MiddleBottomLeft; // Gezegen sayısal verileri
    public string MiddleBottomRight; // Gezegen sayısal verileri
    public float orthographicSize = 5.0f; // Bu gezegen için kamera ortografik boyutu

    [HideInInspector]
    public TextMeshProUGUI nameText; // UI'da gezegen adını gösterecek Text bileşeni
    [HideInInspector]
    public TextMeshProUGUI descriptionText; // UI'da gezegen açıklamasını gösterecek Text bileşeni
    [HideInInspector]
    public TextMeshProUGUI description2Text; // UI'da gezegen açıklamasını gösterecek Text bileşeni
    [HideInInspector]
    public TextMeshProUGUI planetDataText; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    [HideInInspector]  
    public TextMeshProUGUI planetData2Text; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    [HideInInspector]  
    public TextMeshProUGUI planetData3Text; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    [HideInInspector]  
    public TextMeshProUGUI planetData4Text; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    [HideInInspector]  
    public TextMeshProUGUI planetData5Text; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    [HideInInspector]  
    public TextMeshProUGUI planetData6Text; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    [HideInInspector]
    public TextMeshProUGUI planetTitleText; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    [HideInInspector]  
    public TextMeshProUGUI planetTitle2Text; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    [HideInInspector]  
    public TextMeshProUGUI planetTitle3Text; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    [HideInInspector]  
    public TextMeshProUGUI planetTitle4Text; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    [HideInInspector]  
    public TextMeshProUGUI planetTitle5Text; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    [HideInInspector]  
    public TextMeshProUGUI planetTitle6Text; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    [HideInInspector]  
    public TextMeshProUGUI planetMiddleText; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    [HideInInspector]  
    public TextMeshProUGUI planetMiddle2Text; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    [HideInInspector]  
    public TextMeshProUGUI planetMiddle3Text; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    [HideInInspector]  
    public TextMeshProUGUI planetMiddle4Text; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    [HideInInspector] 
    public TextMeshProUGUI planetMiddle5Text; // UI'da gezegen sayısal verilerini gösterecek Text bileşeni
    [HideInInspector] 
    public TextMeshProUGUI MiddleNumText;
    [HideInInspector] 
    public TextMeshProUGUI Middle2NumText;
    [HideInInspector] 
    public TextMeshProUGUI Middle3NumText;

    void Start()
    {
        // Başlangıçta UI panellerini güncelle
        UpdatePlanetInfo();
    }

    public void UpdatePlanetInfo()
    {
        if (nameText != null) nameText.text = planetName;
        if (descriptionText != null) descriptionText.text = planetDescription;
        if (description2Text != null) description2Text.text = KesifGozlem;
        if (planetDataText != null) planetDataText.text = Data1;
        if (planetData2Text != null) planetData2Text.text = Data2;
        if (planetData3Text != null) planetData3Text.text = Data3;
        if (planetData4Text != null) planetData4Text.text = Data4;
        if (planetData5Text != null) planetData5Text.text = Data5;
        if (planetData6Text != null) planetData6Text.text = Data6;
        if (planetMiddleText != null) planetMiddleText.text = MiddleTop;
        if (planetMiddle2Text != null) planetMiddle2Text.text = MiddleTopLeft;
        if (planetMiddle3Text != null) planetMiddle3Text.text = MiddleTopRight;
        if (planetMiddle4Text != null) planetMiddle4Text.text = MiddleBottomLeft;
        if (planetMiddle5Text != null) planetMiddle5Text.text = MiddleBottomRight;
        if (MiddleNumText != null) MiddleNumText.text = MiddleTopNum.ToString();
        if (Middle2NumText != null) Middle2NumText.text = MiddleTopLeftNum.ToString();
        if (Middle3NumText != null) Middle3NumText.text = MiddleTopRightNum.ToString();
        if (planetTitleText != null) planetTitleText.text = Title;
        if (planetTitle2Text != null) planetTitle2Text.text = Title2;
        if (planetTitle3Text != null) planetTitle3Text.text = Title3;
        if (planetTitle4Text != null) planetTitle4Text.text = Title4;
        if (planetTitle5Text != null) planetTitle5Text.text = Title5;
        if (planetTitle6Text != null) planetTitle6Text.text = Title6;
    }

}