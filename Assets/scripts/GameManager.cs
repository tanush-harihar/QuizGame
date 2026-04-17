using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerMaxHP = 100;
    private int playerHP;

    public Enemy[] enemies;
    private int currentEnemyIndex = 0;
    private int enemyHP;

    public QuestionManager questionManager;
    public UIManager uiManager;

    private Question currentQuestion;

    void Start()
    {
        playerHP = playerMaxHP;
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
        enemyHP = enemy.maxHP;

        Debug.Log("Fighting: " + enemy.name);

        // 🔥 Set category based on enemy
        questionManager.SetCategory(currentEnemyIndex);

        // Update UI HP
        uiManager.UpdatePlayerHP(playerHP, playerMaxHP);
        uiManager.UpdateEnemyHP(enemyHP, enemy.maxHP);

        uiManager.SetEnemyName(enemy.name);
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

        // Update UI HP
        uiManager.UpdatePlayerHP(playerHP, playerMaxHP);
        uiManager.UpdateEnemyHP(enemyHP, enemies[currentEnemyIndex].maxHP);

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