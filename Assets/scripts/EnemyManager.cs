using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Animator animator;

    public AnimatorOverrideController[] bosses;

    private int currentBoss = 0;

    void Start()
    {
        LoadBoss(0);
    }

    public void LoadBoss(int index)
    {
        if (index >= bosses.Length) return;

        currentBoss = index;
        animator.runtimeAnimatorController = bosses[index];
    }

    public void NextBoss()
    {
        currentBoss++;

        if (currentBoss < bosses.Length)
        {
            LoadBoss(currentBoss);
        }
        else
        {
            Debug.Log("All bosses done");
        }
    }
}