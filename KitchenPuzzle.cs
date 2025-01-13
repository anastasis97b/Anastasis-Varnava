using UnityEngine;
using UnityEngine.UI;

public class KitchenPuzzle : MonoBehaviour
{
    public InputField answerInput;
    public GameObject lightToActivate; // Φως κουζίνας
    public Text feedbackText;
    public GameObject livingRoomCanvas; // Canvas σαλονιού για ενεργοποίηση

    public bool isSolved = false;

    public void CheckAnswer()
    {
        if (answerInput.text == "45")
        {
            lightToActivate.SetActive(true);
            feedbackText.text = "Σωστά! Το δεύτερο φως άναψε!Τελική πρόκληση";
            livingRoomCanvas.SetActive(true); // Ενεργοποίηση του LivingRoomCanvas
            isSolved = true;
        }
        else
        {
            feedbackText.text = "Λάθος απάντηση, δοκίμασε ξανά!";
        }
    }
}
