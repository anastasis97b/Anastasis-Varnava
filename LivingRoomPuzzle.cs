using UnityEngine;
using UnityEngine.UI;

public class LivingRoomPuzzle : MonoBehaviour
{
    public InputField answerInput;
    public GameObject lightToActivate; // Φως σαλονιού
    public Text feedbackText;

    public bool isSolved = false;

    public void CheckAnswer()
    {
        if (answerInput.text == "4")
        {
            lightToActivate.SetActive(true);
            feedbackText.text = "Σωστά! Το τρίτο φως άναψε!Είσαι ελεύθερος να φύγεις!";
            isSolved = true;
        }
        else
        {
            feedbackText.text = "Λάθος απάντηση, ξαναπροσπάθησε!";
        }
    }
}
