using UnityEngine;
using UnityEngine.UI;
using SojaExiles;

public class DoorUnlockPuzzle : MonoBehaviour
{
    public InputField codeInput;            // Πεδίο εισαγωγής κωδικού
    public Text feedbackText;               // Κείμενο για το feedback (hint/λάθος)
    public opencloseDoor doorScript;        // Αναφορά στο script που διαχειρίζεται την πόρτα
    public string correctCode = "975";      // Σωστός τριψήφιος κωδικός

    void Start()
    {
        feedbackText.text = ""; // Καθαρισμός feedback στην αρχή
    }

    public void CheckCode()
    {
        if (codeInput.text == correctCode)
        {
            feedbackText.text = "Μπράβο,είσαι κοντά στην ελευθέρια! Η πόρτα ξεκλειδώθηκε.";
            feedbackText.color = Color.green;

            // Ξεκλείδωμα της πόρτας μέσω του opencloseDoor script
            if (doorScript != null)
            {
                doorScript.UnlockDoor();
            }
        }
        else
        {
            feedbackText.text = "Λάθος κωδικός. Ψάξε καλά στην κουζίνα, το μπάνιο και το μικρό Υπνοδωμάτιο!";
            feedbackText.color = Color.red;
        }
    }
}
