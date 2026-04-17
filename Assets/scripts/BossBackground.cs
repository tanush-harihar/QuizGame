using UnityEngine;
using UnityEngine.UI;

public class BossBackgroundManager : MonoBehaviour
{
    public SpriteRenderer backgroundImage;

    public Sprite boss1;
    public Sprite boss2;
    public Sprite boss3;
    public Sprite boss4;

    public void SetBossBackground(int bossIndex)
    {
        switch (bossIndex)
        {
            case 1:
                backgroundImage.sprite = boss1;
                break;
            case 2:
                backgroundImage.sprite = boss2;
                break;
            case 3:
                backgroundImage.sprite = boss3;
                break;
            case 4:
                backgroundImage.sprite = boss4;
                break;
        }
    }
}