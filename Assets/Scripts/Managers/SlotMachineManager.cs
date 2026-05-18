using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotMachineManager : MonoBehaviour
{
 
    // REELS
   
    [Header("Reels")]
    public ReelController reel1;
    public ReelController reel2;
    public ReelController reel3;

    // LEVER
 
    [Header("Lever")]
    public LeverAnimation leverAnimation;

    // AUDIO

    [Header("Audio")]
    public AudioSource leverAudio;
    public AudioSource stopAudio;
    public AudioSource winAudio;

    // UI
    
    [Header("UI")]
    public GameObject jackpotPopup;
    public GameObject gameOverPanel;

    [Header("UI Text")]
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI currentBetText;

    // BET SYSTEM

    [Header("Bet System")]
    public int currentCoins = 1000;
    public int currentBet = 50;

    // Prevent multiple spins
    private bool isSpinning = false;

    
    // START

    private void Start()
    {
        // Update UI when game starts
        UpdateUI();

        // Hide popups at start
        jackpotPopup.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    // Called when player selects a bet amount.
    public void SelectBet(int betAmount)
    {
        // Set current bet
        currentBet = betAmount;

        // Update UI text
        UpdateUI();

        // Start spin automatically
        Spin();
    }

    // Starts the slot machine spin.
    public void Spin()
    {
        // Hide jackpot popup before spin
        jackpotPopup.SetActive(false);

        // Prevent multiple spins
        if (isSpinning)
            return;

        // Check if player has enough coins
        if (currentCoins < currentBet)
        {
            Debug.Log("NOT ENOUGH COINS");

            CheckGameOver();

            return;
        }

        // Deduct coins
        currentCoins -= currentBet;

        // Update UI
        UpdateUI();

        // Start spin sequence
        StartCoroutine(StartSpinSequence());
    }
// Plays lever animation and sound.
   
    private IEnumerator StartSpinSequence()
    {
        isSpinning = true;

        // Play lever animation
        leverAnimation.PlayLever();

        // Play lever sound
        leverAudio.Play();

        // Small delay before reels spin
        yield return new WaitForSeconds(0.6f);

        StartCoroutine(SpinRoutine());
    }

 // Spins and stops reels one by one.
   
    private IEnumerator SpinRoutine()
    {
        // Start all reels
        reel1.StartSpin();
        reel2.StartSpin();
        reel3.StartSpin();

        // ------------------------------

        // Stop reel 1
        yield return new WaitForSeconds(2.5f);

        reel1.StopSpin();

        stopAudio.Play();

        // ------------------------------

        // Stop reel 2
        yield return new WaitForSeconds(0.5f);

        reel2.StopSpin();

        stopAudio.Play();

        // ------------------------------

        // Stop reel 3
        yield return new WaitForSeconds(0.5f);

        reel3.StopSpin();

        stopAudio.Play();

        // ------------------------------

        // Small delay before result check
        yield return new WaitForSeconds(0.3f);

        // Check win result
        CheckWin();

        isSpinning = false;
    }
    // Checks if all center symbols match.
    private void CheckWin()
    {
        // Get center symbols
        string symbol1 = GetVisibleSymbol(reel1);
        string symbol2 = GetVisibleSymbol(reel2);
        string symbol3 = GetVisibleSymbol(reel3);

        Debug.Log(symbol1 + " | " + symbol2 + " | " + symbol3);

        // Win condition
        if (symbol1 == symbol2 &&
            symbol2 == symbol3)
        {
            HandleWin();
        }
        else
        {
            HandleLose();
        }
    }
// Handles player win.
    private void HandleWin()
    {
        Debug.Log("YOU WIN!");

        // Calculate payout
        int payout = currentBet * 5;

        // Add payout coins
        currentCoins += payout;

        // Update UI
        UpdateUI();

        // Play win sound
        winAudio.Play();

        // Show jackpot popup
        jackpotPopup.SetActive(true);

        // Hide popup after sound ends
        StartCoroutine(HideJackpotPopup());
    }

    /// Handles player lose.
    private void HandleLose()
    {
        Debug.Log("LOSE");

        // Check game over
        CheckGameOver();
    }
    // Finds symbol closest to center line.
    
    private string GetVisibleSymbol(ReelController reel)
    {
        float closestDistance = Mathf.Infinity;

        string selectedSymbol = "";

        foreach (Transform child in reel.symbolContainer)
        {
            // Center target position
            float targetY = 0f;

            // Current symbol position
            float currentY =
                child.localPosition.y +
                reel.symbolContainer.localPosition.y;

            // Distance from center
            float distance =
                Mathf.Abs(currentY - targetY);

            // Find closest symbol
            if (distance < closestDistance)
            {
                closestDistance = distance;

                selectedSymbol =
                    child.GetComponent<Image>()
                    .sprite.name;
            }
        }

        return selectedSymbol;
    }

    // Hides jackpot popup after win sound.
    
    private IEnumerator HideJackpotPopup()
    {
        yield return new WaitForSeconds(
            winAudio.clip.length
        );

        jackpotPopup.SetActive(false);
    }
    // Checks if player has no coins left.
    private void CheckGameOver()
    {
        if (currentCoins <= 0)
        {
            gameOverPanel.SetActive(true);
        }
    }
    // Resets game values.
    public void PlayAgain()
    {
        // Reset coins
        currentCoins = 1000;

        // Reset bet
        currentBet = 50;

        // Update UI
        UpdateUI();

        // Hide game over panel
        gameOverPanel.SetActive(false);
    }


    
    // Updates coin and bet text.
    
    private void UpdateUI()
    {
        coinsText.text =
            "COINS : " + currentCoins;

        currentBetText.text =
            "CURRENT BET : " + currentBet;
    }
}