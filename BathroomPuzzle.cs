using UnityEngine;
using UnityEngine.UI;

public class BathroomPuzzle : MonoBehaviour
{
    public InputField answerInput;
    public GameObject lightToActivate; // Φως τουαλέτας
    public Text feedbackText;
    public GameObject kitchenCanvas; // Canvas κουζίνας για ενεργοποίηση

    public bool isSolved = false;

    public void CheckAnswer()
    {
        if (answerInput.text == "3")
        {
            lightToActivate.SetActive(true);
            feedbackText.text = "Σωστά! Το πρώτο φως άναψε!";
            kitchenCanvas.SetActive(true); // Ενεργοποίηση του KitchenCanvas
            isSolved = true;
        }
        else
        {
            feedbackText.text = "Λάθος απάντηση, προσπάθησε ξανά!";
        }
    }
}
