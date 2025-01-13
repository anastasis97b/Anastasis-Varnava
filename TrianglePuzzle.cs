using UnityEngine;
using UnityEngine.UI;
using SojaExiles;

public class TrianglePuzzle : MonoBehaviour
{
    public Text QuestionText;          // Το κείμενο της ερώτησης
    public InputField AnswerInput;     // Το πεδίο για την απάντηση
    public Button SubmitButton;        // Το κουμπί υποβολής
    public Text HintText;              // Το hint κείμενο
    public Text FeedbackText;          // Το κείμενο feedback
    public opencloseDoor doorScript;   // Αναφορά στο script της πόρτας

    private bool isSolved = false;     // Κατάσταση επίλυσης

    void Start()
    {
        QuestionText.text = "Σε ένα ορθογώνιο τρίγωνο ABC, όπου AB=6 cm, BC=8 cm και η γωνία C είναι ορθή. " +
                            "Βρες την υποτείνουσα.";
        SubmitButton.onClick.AddListener(CheckAnswer);
        HintText.text = "";
        FeedbackText.text = "";
    }

    void CheckAnswer()
    {
        if (isSolved) return;

        string playerAnswer = AnswerInput.text.Trim();
        if (playerAnswer == "10,0.8" || playerAnswer == "10 0.8") // Ελέγχει τη σωστή απάντηση
        {
            FeedbackText.text = "Σωστή απάντηση! Η πόρτα ξεκλειδώθηκε.";
            FeedbackText.color = Color.green;
            HintText.text = "";
            isSolved = true;

            // Ξεκλειδώνει την πόρτα
            if (doorScript != null)
            {
                doorScript.UnlockDoor();
                Debug.Log("Η πόρτα ξεκλειδώθηκε μέσω του TrianglePuzzle script.");
            }
            else
            {
                Debug.LogError("DoorScript δεν έχει οριστεί στο Inspector!");
            }
        }
        else
        {
            FeedbackText.text = "Λάθος απάντηση. Προσπάθησε ξανά!";
            FeedbackText.color = Color.red;
            HintText.text = "Υπόδειξη: Χρησιμοποίησε το Πυθαγόρειο Θεώρημα και τις τριγωνομετρικές σχέσεις.";
        }
    }
}
