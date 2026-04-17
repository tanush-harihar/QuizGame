using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI[] answerTexts;
    public TextMeshProUGUI enemyNameText;

    public Slider playerHPBar;
    public Slider enemyHPBar;

    public void SetQuestion(string question, string[] answers)
    {
        questionText.text = question;

        for (int i = 0; i < answerTexts.Length; i++)
        {
            if (i < answers.Length)
            {
                answerTexts[i].text = answers[i];
                answerTexts[i].transform.parent.gameObject.SetActive(true);
            }
            else
            {
                answerTexts[i].text = "";
                answerTexts[i].transform.parent.gameObject.SetActive(false);
            }
        }
    }
    public void SetEnemyName(string name)
    {
        enemyNameText.text = name;

    }
    public void UpdatePlayerHP(int current, int max)
    {
        playerHPBar.value = (float)current / max;
    }

    public void UpdateEnemyHP(int current, int max)
    {

        enemyHPBar.value = (float)current / max;
    }
}