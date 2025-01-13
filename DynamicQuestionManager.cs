using UnityEngine;
using UnityEngine.UI;
using SojaExiles;

public class DynamicQuestionManager : MonoBehaviour
{
    [Header("UI Components")]
    public Text questionText;           // Κείμενο για την ερώτηση
    public Text tipText;                // Κείμενο για το tip
    public Button[] options;            // Κουμπιά επιλογών
    public Button retryButton;          // Κουμπί "Δοκίμασε Ξανά"

    [Header("References")]
    public opencloseDoor door;          // Πόρτα που ξεκλειδώνει

    private Question[] questions;       // Πίνακας ερωτήσεων
    private int currentQuestionIndex = -1; // Χρησιμοποιούμε -1 για να αρχίσουμε με νέα ερώτηση κάθε φορά

    void Start()
    {
        LoadQuestions();
        NextQuestion(); // Φόρτωση της πρώτης ερώτησης
        retryButton.onClick.AddListener(NextQuestion); // Συνδέουμε το κουμπί "Δοκίμασε Ξανά"
        retryButton.gameObject.SetActive(false);       // Αρχικά κρυφό
    }

    void LoadQuestions()
    {
        // Ερωτήσεις αποκλειστικά από το κεφάλαιο πιθανότητες και ζάρια
        questions = new Question[]
        {
            new Question("Ποια είναι η πιθανότητα να φέρεις 7 με δύο ζάρια;",
                new string[] { "1/6", "1/36", "6/36", "5/36" }, 2,
                "Το 7 είναι το πιο πιθανό άθροισμα γιατί έχει 6 συνδυασμούς για να εμφανιστεί."),

            new Question("Ποια είναι η πιθανότητα να φέρεις 2 με δύο ζάρια;",
                new string[] { "1/36", "2/36", "3/36", "6/36" }, 0,
                "Το 2 μπορεί να εμφανιστεί μόνο με έναν συνδυασμό (1,1), άρα η πιθανότητα είναι 1/36."),

            new Question("Ποια είναι η πιθανότητα να φέρεις άθροισμα μεγαλύτερο του 10;",
                new string[] { "3/36", "6/36", "12/36", "15/36" }, 1,
                "Υπάρχουν 3 πιθανοί συνδυασμοί: (5,6), (6,5), (6,6). Άρα η πιθανότητα είναι 3/36."),

            new Question("Ποια είναι η πιθανότητα να φέρεις άθροισμα ίσο με 6;",
                new string[] { "5/36", "4/36", "3/36", "2/36" }, 0,
                "Υπάρχουν 5 πιθανοί συνδυασμοί για να φέρεις 6: (1,5), (2,4), (3,3), (4,2), (5,1).")
        };
    }

    void NextQuestion()
    {
        // Επιλογή επόμενης ερώτησης
        currentQuestionIndex = (currentQuestionIndex + 1) % questions.Length;

        questionText.text = questions[currentQuestionIndex].question;
        tipText.text = ""; // Καθαρίζει το tip

        for (int i = 0; i < options.Length; i++)
        {
            options[i].gameObject.SetActive(true);
            options[i].GetComponentInChildren<Text>().text = questions[currentQuestionIndex].answers[i];
            int index = i;
            options[i].onClick.RemoveAllListeners();
            options[i].onClick.AddListener(() => CheckAnswer(index));
        }

        retryButton.gameObject.SetActive(false); // Κρύβει το κουμπί "Δοκίμασε Ξανά"
    }

    void CheckAnswer(int selectedIndex)
    {
        if (selectedIndex == questions[currentQuestionIndex].correctAnswerIndex)
        {
            questionText.text = "Σωστή απάντηση! Η πόρτα ξεκλειδώθηκε.";
            door.UnlockDoor(); // Ξεκλείδωμα της πόρτας
            foreach (var button in options)
            {
                button.gameObject.SetActive(false); // Κρύβει τις επιλογές
            }
        }
        else
        {
            tipText.text = "Λάθος! " + questions[currentQuestionIndex].tip;
            retryButton.gameObject.SetActive(true); // Εμφάνιση του κουμπιού "Δοκίμασε Ξανά"
            foreach (var button in options)
            {
                button.gameObject.SetActive(false); // Κρύβει τις επιλογές
            }
        }
    }
}

// Κλάση ερωτήσεων με tip
public class Question
{
    public string question;
    public string[] answers;
    public int correctAnswerIndex;
    public string tip;

    public Question(string question, string[] answers, int correctAnswerIndex, string tip)
    {
        this.question = question;
        this.answers = answers;
        this.correctAnswerIndex = correctAnswerIndex;
        this.tip = tip;
    }
}
