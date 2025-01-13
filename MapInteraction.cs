using UnityEngine;
using UnityEngine.UI;
using SojaExiles;

public class MapInteraction : MonoBehaviour
{
    public GameObject puzzleCanvas; // Το Canvas με την ερώτηση και τα στοιχεία
    public GameObject hintText;     // Το Hint για βοήθεια αν ο μαθητής απαντήσει λάθος
    public Button submitButton;     // Το κουμπί για την απάντηση
    public InputField answerInput;  // Το πεδίο απάντησης
    public Text feedbackText;       // Για το feedback (σωστό/λάθος)
    public opencloseDoor doorScript; // Αναφορά στο script της πόρτας

    private bool isPuzzleActive = false; // Ελέγχει αν ο γρίφος είναι ενεργός

    void Start()
    {
        // Αρχικά απενεργοποιούμε το Puzzle και τα hints
        puzzleCanvas.SetActive(false);
        hintText.SetActive(false);

        // Προσθέτουμε τον listener για το κουμπί απάντησης
        submitButton.onClick.AddListener(CheckAnswer);
    }

    void OnMouseDown()
    {
        if (!isPuzzleActive)
        {
            ActivatePuzzle();
        }
    }

    void ActivatePuzzle()
    {
        // Ενεργοποιούμε το Puzzle UI
        puzzleCanvas.SetActive(true);
        isPuzzleActive = true;
    }

    void CheckAnswer()
    {
        string correctAnswer = "10"; // Η σωστή απάντηση (όπως υπολογίσαμε προηγουμένως)

        if (answerInput.text == correctAnswer)
        {
            feedbackText.text = "Σωστά! Η πόρτα ξεκλείδωσε!";
            hintText.SetActive(false);
            puzzleCanvas.SetActive(false);

            // Ξεκλείδωμα της πόρτας
            if (doorScript != null)
            {
                doorScript.isLocked = false;
                doorScript.UnlockDoor(); // Εφόσον υπάρχει αυτή η μέθοδος στο script της πόρτας
            }
        }
        else
        {
            feedbackText.text = "Λάθος απάντηση. Προσπάθησε ξανά!";
            hintText.SetActive(true);
        }
    }
}
