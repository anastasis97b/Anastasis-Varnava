using UnityEngine;
using UnityEngine.UI;
using SojaExiles;

public class LinearEquationPuzzle : MonoBehaviour
{
    public Text questionText;          // Το κείμενο της ερώτησης
    public InputField inputX;          // Πεδίο εισαγωγής για το x
    public InputField inputY;          // Πεδίο εισαγωγής για το y
    public Text feedbackText;          // Κείμενο ανατροφοδότησης
    public GameObject door;            // Η πόρτα που θα ξεκλειδώσει
    public string correctX = "1";      // Σωστή τιμή για το x
    public string correctY = "3";      // Σωστή τιμή για το y

    void Start()
    {
        // Αρχικό feedback
        feedbackText.text = "Βρες το σημείο τομής!";
    }

    public void CheckAnswer()
    {
        // Έλεγχος απαντήσεων
        if (inputX.text == correctX && inputY.text == correctY)
        {
            feedbackText.text = "Σωστή απάντηση! Η πόρτα άνοιξε!";
            UnlockDoor();
        }
        else
        {
            feedbackText.text = "Λάθος απάντηση! Δοκίμασε ξανά!";
        }
    }

    void UnlockDoor()
    {
        // Ενεργοποιούμε την πόρτα αν έχει Script opencloseDoor
        var doorScript = door.GetComponent<opencloseDoor>();
        if (doorScript != null)
        {
            doorScript.UnlockDoor(); // Ξεκλειδώνουμε την πόρτα
            Debug.Log("Η πόρτα ξεκλειδώθηκε μέσω του γρίφου!");
        }
        else
        {
            Debug.LogError("Δεν βρέθηκε το Script opencloseDoor στην πόρτα!");
        }
    }
}
