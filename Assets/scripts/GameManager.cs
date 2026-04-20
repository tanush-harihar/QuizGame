using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerMaxHP = 100;
    private int playerHP;
    private int score = 0;
    public Enemy[] enemies;
    private int currentEnemyIndex = 0;
    private int enemyHP;
    private int enemyMaxHP;

    public BossBackgroundManager bgManager;
    public QuestionManager questionManager;
    public UIManager uiManager;

    private Question currentQuestion;

    void Start()
    {
        uiManager.HideEndScreen();
        playerHP = playerMaxHP;

        int selectedCategory = GameSettings.selectedCategory;
        questionManager.SetCategory(selectedCategory);

        StartEnemy();
    }

    void StartEnemy()
    {

        if (currentEnemyIndex >= enemies.Length)
        {
            Debug.Log("YOU WIN!");
            return;
        }

        Enemy enemy = enemies[currentEnemyIndex];

        // 🔥 Scale HP
        enemyMaxHP = enemy.health + (currentEnemyIndex * 50);
        enemyHP = enemyMaxHP;

        uiManager.SetEnemyVisual(enemy.sprite, enemy.animator);

        Debug.Log("Fighting: " + enemy.name + " | HP: " + enemyHP);

        // ❌ REMOVE THIS LINE (IMPORTANT)
        // questionManager.SetCategory(currentEnemyIndex);

        // UI Updates
        uiManager.UpdatePlayerHP(playerHP, playerMaxHP);
        uiManager.UpdateEnemyHP(enemyHP, enemyMaxHP);

        uiManager.SetEnemyName(enemy.name);

        bgManager.SetBossBackground(currentEnemyIndex+1);

        NextTurn();
    }

    void NextTurn()
    {
        currentQuestion = questionManager.GetNextQuestion();

        if (currentQuestion == null)
        {
            Debug.LogError("Question is NULL!");
            return;
        }

        uiManager.SetQuestion(currentQuestion.questionText, currentQuestion.answers);
    }

    public void SubmitAnswer(int index)
    {
        if (currentQuestion == null)
        {
            Debug.LogError("No current question!");
            return;
        }
        if (index < 0)
        {
            Debug.LogError("Invalid answer index!");
            return;
        }
        bool isCorrect = index == currentQuestion.correctIndex;

        // Clamp HP (prevents negative weird UI)
        enemyHP = Mathf.Max(enemyHP, 0);
        playerHP = Mathf.Max(playerHP, 0);

        // Update UI
        uiManager.UpdatePlayerHP(playerHP, playerMaxHP);
        uiManager.UpdateEnemyHP(enemyHP, enemyMaxHP);
        if (isCorrect)
        {
            enemyHP -= 20;
            score += 10;
        }
        else
        {
            playerHP -= 15;
        }
        CheckGameState();
    }

    void CheckGameState()
    {
        if (enemyHP <= 0)
        {
            currentEnemyIndex++;

            if (currentEnemyIndex >= enemies.Length)
            {
                uiManager.ShowEndScreen(true, score); // only after all enemies
            }
            else
            {
                StartEnemy();
            }
        }
        else if (playerHP <= 0)
        {
            uiManager.ShowEndScreen(false, score);
        }
        else
        {
            NextTurn();
        }
    }
}