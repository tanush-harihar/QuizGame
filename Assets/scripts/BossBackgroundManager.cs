using UnityEngine;
using UnityEngine.UI;

public class BossBackgroundManager : MonoBehaviour
{
    public Image backgroundImage;
    public Sprite[] backgrounds;

    public void SetBossBackground(int index)
    {
        if (index < 0 || index >= backgrounds.Length)
        {
            Debug.LogWarning("Invalid background index");
            return;
        }

        backgroundImage.sprite = backgrounds[index];
    }
}