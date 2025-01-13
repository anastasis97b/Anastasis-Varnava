using UnityEngine;
using UnityEngine.UI;
using SojaExiles;
public class TriangleGame : MonoBehaviour
{
    public Slider angleSlider; // Slider για τη γωνία
    public Text angleText; // Κείμενο για την προβολή της γωνίας
    public Text resultText; // Κείμενο αποτελέσματος
    public float correctAngle; // Η σωστή γωνία
    public GameObject door; // Αντικείμενο της πόρτας

    private opencloseDoor doorScript; // Αναφορά στο script της πόρτας

    void Start()
    {
        // Αρχικοποίηση του slider και του κειμένου
        angleSlider.minValue = 0;
        angleSlider.maxValue = 180;
        angleSlider.value = 0;
        UpdateAngleText();

        // Εύρεση του script της πόρτας
        doorScript = door.GetComponent<opencloseDoor>();
    }

    void Update()
    {
        UpdateAngleText();
    }

    public void CheckAnswer()
    {
        float enteredAngle = angleSlider.value;

        // Έλεγχος αν η απάντηση είναι σωστή
        if (Mathf.Abs(enteredAngle - correctAngle) < 0.1f)
        {
            resultText.text = "Σωστό! Η πόρτα ξεκλείδωσε!";
            resultText.color = Color.green;

            if (doorScript != null)
            {
                doorScript.UnlockDoor(); // Ξεκλείδωσε την πόρτα
            }
        }
        else
        {
            resultText.text = "Λάθος. Προσπάθησε ξανά.";
            resultText.color = Color.red;
        }
    }

    private void UpdateAngleText()
    {
        angleText.text = "Γωνία: " + angleSlider.value.ToString("F1") + "°";
    }
}
