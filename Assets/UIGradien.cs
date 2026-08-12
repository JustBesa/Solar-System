using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class CustomGradientPanel : MonoBehaviour
{
    public Color color1 = Color.white;
    public Color color2 = Color.black;
    [Range(0f, 1f)]
    public float gradientPosition = 0.5f; // Gradient geçiş noktası
    private Image image;

    private void OnEnable()
    {
        image = GetComponent<Image>();
        if (image == null)
        {
            Debug.LogError("CustomGradientPanel requires an Image component.");
            return;
        }
        UpdateGradient();
    }

    private void OnValidate()
    {
        UpdateGradient();
    }

    private void UpdateGradient()
    {
        if (image == null) return;

        RectTransform rectTransform = GetComponent<RectTransform>();
        int width = Mathf.RoundToInt(rectTransform.rect.width);
        int height = Mathf.RoundToInt(rectTransform.rect.height);

        Texture2D texture = new Texture2D(width, height);
        Color[] colors = new Color[width * height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float t = Mathf.InverseLerp(0, height - 1, y);
                colors[y * width + x] = Color.Lerp(color1, color2, t);
            }
        }

        texture.SetPixels(colors);
        texture.Apply();

        image.sprite = Sprite.Create(texture, new Rect(0, 0, width, height), new Vector2(0.5f, 0.5f));
        image.type = Image.Type.Simple;

        // Bu kısım, sprite'ı doğru boyutta gösterir
        image.preserveAspect = true;
    }
}
