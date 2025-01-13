using UnityEngine;
using UnityEngine.UI;

public class ComputerRiddle : MonoBehaviour
{
    public InputField inputField;
    public Text feedbackText;
    public string correctAnswer;
    public string hintMessage;

    public void CheckAnswer()
    {
        if (inputField.text == correctAnswer)
        {
            feedbackText.text = "Correct!";
            print("The answer is correct!");
        }
        else
        {
            feedbackText.text = hintMessage;
            print("Try again.");
        }
    }
}
