using UnityEngine;

public class FinalGameController : MonoBehaviour
{
    public GameObject light1, light2, light3;
    public GameObject endGameMessage; // Canvas ή Text για το τέλος
    private bool gameEnded = false; // Σημαία για το αν έχει τερματιστεί το παιχνίδι

    void Update()
    {
        if (!gameEnded && light1.activeInHierarchy && light2.activeInHierarchy && light3.activeInHierarchy)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameEnded = true; // Ορίζουμε τη σημαία για να μην ξανατρέξει
        endGameMessage.SetActive(true); // Εμφανίζουμε το μήνυμα
        Debug.Log("Συγχαρητήρια! Τελείωσες το παιχνίδι!");

#if UNITY_EDITOR
    // Αν τρέχεις στο Unity Editor, σταματά το Play Mode
    UnityEditor.EditorApplication.isPlaying = false;
#else
        // Αν τρέχεις σε κανονικό build, κλείνει η εφαρμογή
        Application.Quit();
#endif
    }

}
