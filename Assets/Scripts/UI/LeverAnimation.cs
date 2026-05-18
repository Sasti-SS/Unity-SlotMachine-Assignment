using UnityEngine;

public class LeverAnimation : MonoBehaviour
{
    // Animator used for lever pull animation
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        // Force idle state at game start
        animator.Play("Idle", 0, 0f);
    }

    // Called when player clicks the lever
    public void PlayLever()
    {
        animator.SetTrigger("Trigger");
    }
}