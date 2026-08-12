using UnityEngine;
using UnityEngine.UI;

public class FillBarController : MonoBehaviour
{
    public Image fillBar; 
    public GameObject panel; 
    private float fillAmount;

    public void UpdateFillBar(float fillAmount)
    {
        if (fillAmount > 0)
        {
            fillBar.fillAmount = fillAmount / 100f;
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
    }
}
