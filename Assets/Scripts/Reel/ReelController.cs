using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ReelController : MonoBehaviour
{
    [Header("Reel Settings")]
    public RectTransform symbolContainer;

    public float spinSpeed = 3000f;

    public float symbolSpacing = 120f;

    public int symbolCount = 12;

    [Header("Symbols")]
    public Sprite[] symbolSprites;

    // Controls reel spinning state
    private bool isSpinning = false;

    private void Start()
    {
        // Align reel correctly at game start
        Vector2 startPos =
            symbolContainer.anchoredPosition;

        float snappedY =
            Mathf.Round(startPos.y / symbolSpacing)
            * symbolSpacing;

        symbolContainer.anchoredPosition =
            new Vector2(startPos.x, snappedY);

        isSpinning = false;
    }

    private void Update()
    {
        // Continuously spin reel
        if (isSpinning)
        {
            SpinReel();
        }
    }

    public void StartSpin()
    {
        // Randomize symbols before spinning
        RandomizeSymbols();

        isSpinning = true;
    }

    public void StopSpin()
    {
        isSpinning = false;

        // Final aligned stop position
        float snappedY = -120f;

        StartCoroutine(
            SmoothStop(snappedY)
        );
    }

    IEnumerator SmoothStop(float targetY)
    {
        Vector2 startPos =
            symbolContainer.anchoredPosition;

        Vector2 targetPos =
            new Vector2(startPos.x, targetY);

        float timer = 0f;

        while (timer < 0.2f)
        {
            timer += Time.deltaTime * 5f;

            symbolContainer.anchoredPosition =
                Vector2.Lerp(
                    startPos,
                    targetPos,
                    timer
                );

            yield return null;
        }

        symbolContainer.anchoredPosition =
            targetPos;
    }

    private void SpinReel()
    {
        // Move reel downward
        symbolContainer.anchoredPosition +=
            Vector2.down *
            spinSpeed *
            Time.deltaTime;

        // Loop reel strip continuously
        if (symbolContainer.anchoredPosition.y <= -960f)
        {
            symbolContainer.anchoredPosition =
                new Vector2(
                    symbolContainer.anchoredPosition.x,
                    0f
                );
        }
    }

    private void RandomizeSymbols()
    {
        foreach (Transform child in symbolContainer)
        {
            Image symbolImage =
                child.GetComponent<Image>();

            int randomIndex =
                Random.Range(
                    0,
                    symbolSprites.Length
                );

            symbolImage.sprite =
                symbolSprites[randomIndex];
        }
    }
}