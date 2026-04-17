using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerMaxHP = 100;
    private int playerHP;

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

        Debug.Log("Fighting: " + enemy.name + " | HP: " + enemyHP);

        // ❌ REMOVE THIS LINE (IMPORTANT)
        // questionManager.SetCategory(currentEnemyIndex);

        // UI Updates
        uiManager.UpdatePlayerHP(playerHP, playerMaxHP);
        uiManager.UpdateEnemyHP(enemyHP, enemyMaxHP);

        uiManager.SetEnemyName(enemy.name);

        if (bgManager != null)
            bgManager.SetBossBackground(currentEnemyIndex + 1);

        NextTurn();
    }

    void NextTurn()
    {
        currentQuestion = questionManager.GetNextQuestion();

        if (currentQuestion == null)
            return;

        uiManager.SetQuestion(currentQuestion.questionText, currentQuestion.answers);
    }

    public void SubmitAnswer(int index)
    {
        bool isCorrect = questionManager.CheckAnswer(index);

        if (isCorrect)
        {
            enemyHP -= 20;
            Debug.Log("Correct! Enemy takes damage.");
        }
        else
        {
            playerHP -= 15;
            Debug.Log("Wrong! Player takes damage.");
        }

        // Clamp HP (prevents negative weird UI)
        enemyHP = Mathf.Max(enemyHP, 0);
        playerHP = Mathf.Max(playerHP, 0);

        // Update UI
        uiManager.UpdatePlayerHP(playerHP, playerMaxHP);
        uiManager.UpdateEnemyHP(enemyHP, enemyMaxHP);

        CheckGameState();
    }

    void CheckGameState()
    {
        if (enemyHP <= 0)
        {
            Debug.Log("Enemy Defeated!");
            currentEnemyIndex++;
            StartEnemy();
        }
        else if (playerHP <= 0)
        {
            Debug.Log("GAME OVER!");
        }
        else
        {
            NextTurn();
        }
    }
}