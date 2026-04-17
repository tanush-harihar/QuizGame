using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator not found on " + gameObject.name);
        }
    }

    // Call this when enemy dies
    public void TriggerDeath()
    {
        StartCoroutine(DeathRoutine());
    }

    private System.Collections.IEnumerator DeathRoutine()
    {
        // Set isDead = true
        animator.SetBool("isDead", true);

        // Wait for animation duration (adjust this!)
        animator.SetBool("isDead", false);
        yield return new WaitForSeconds(2f);

        // Reset isDead = false

    }
}