using UnityEngine;
using UnityEngine.UI;
using SojaExiles; // Αναφορά στο script της πόρτας

public class TreasureMapPuzzle : MonoBehaviour
{
    [Header("UI Elements")]
    public Text questionText;
    public InputField answerInput;
    public Button submitButton;
    public Text feedbackText;

    [Header("Door Script")]
    public opencloseDoor doorScript; // Αναφορά στην πόρτα

    private string correctAnswer = "10"; // Η σωστή απάντηση

    void Start()
    {
        // Ρύθμιση της ερώτησης
        questionText.text = "Σε έναν χάρτη, το σημείο Α έχει συντεταγμένες (0,0) και το σημείο Β έχει συντεταγμένες (6,8). " +
                            "Ποια είναι η απόσταση AB;";
        feedbackText.text = ""; // Καθαρίζουμε το feedback

        // Συνδέουμε το κουμπί
        submitButton.onClick.AddListener(CheckAnswer);
    }

    void CheckAnswer()
    {
        string userAnswer = answerInput.text.Trim();

        if (userAnswer == correctAnswer)
        {
            feedbackText.text = "Σωστή απάντηση! Η πόρτα ξεκλειδώθηκε.";
            feedbackText.color = Color.green;

            // Ξεκλειδώνουμε την πόρτα
            if (doorScript != null)
            {
                doorScript.UnlockDoor();
                Debug.Log("Η πόρτα ξεκλείδωσε!");
            }
        }
        else
        {
            feedbackText.text = "Λάθος απάντηση. Χρησιμοποίησε το Πυθαγόρειο Θεώρημα!";
            feedbackText.color = Color.red;
        }
    }
}
