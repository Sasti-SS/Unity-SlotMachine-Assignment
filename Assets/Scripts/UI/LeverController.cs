using System.Collections;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    [Header("Lever Settings")]
    public RectTransform leverTransform;

    // Distance lever moves downward
    public float pullDistance = 40f;

    // Animation speed
    public float animationSpeed = 6f;

    // Original lever position
    private Vector2 startPosition;

    private void Start()
    {
        // Store starting position
        startPosition = leverTransform.anchoredPosition;
    }

    public void PullLever()
    {
        StartCoroutine(PullAnimation());
    }

    
    IEnumerator PullAnimation()
    {
        Vector2 pulledPosition = startPosition + Vector2.down * pullDistance;

        float timer = 0f;

        // Move lever downward
        while (timer < 1f)
        {
            timer += Time.deltaTime * animationSpeed;

            leverTransform.anchoredPosition =
                Vector2.Lerp(startPosition, pulledPosition, timer);

            yield return null;
        }

        timer = 0f;

        // Move lever back upward
        while (timer < 1f)
        {
            timer += Time.deltaTime * animationSpeed;

            leverTransform.anchoredPosition =
                Vector2.Lerp(pulledPosition, startPosition, timer);

            yield return null;
        }

        // Ensure exact final position
        leverTransform.anchoredPosition = startPosition;
    }
}