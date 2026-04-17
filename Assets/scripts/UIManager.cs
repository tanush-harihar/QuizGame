using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public UnityEngine.UI.Image enemyImage;
    public Animator enemyAnimator;

    public void SetEnemyVisual(Sprite sprite, RuntimeAnimatorController anim)
    {
        if (enemyImage != null)
            enemyImage.sprite = sprite;

        if (enemyAnimator != null && anim != null)
            enemyAnimator.runtimeAnimatorController = anim;
    }
    public GameObject endPanel;
    public TMPro.TextMeshProUGUI resultText;
    public TMPro.TextMeshProUGUI scoreText;

    public void ShowEndScreen(bool isWin, int score)
    {
        endPanel.SetActive(true);

        if (isWin)
            resultText.text = "YOU WIN!";
        else
            resultText.text = "GAME OVER";

        scoreText.text = "Score: " + score;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void HideEndScreen()
    {
        if (endPanel != null)
            endPanel.SetActive(false);
    }
}