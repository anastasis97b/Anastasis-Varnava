using UnityEngine;
using UnityEngine.UI;

public class TriangleManager : MonoBehaviour
{
    public Transform[] triangleAPoints; // Κορυφές τριγώνου Α
    public Transform[] triangleBPoints; // Κορυφές τριγώνου Β
    public Text resultText; // Κείμενο αποτελέσματος

    void Start()
    {
        resultText.text = "";
    }

    public void CheckEquality()
    {
        float[] sidesA = CalculateSides(triangleAPoints);
        float[] sidesB = CalculateSides(triangleBPoints);

        System.Array.Sort(sidesA);
        System.Array.Sort(sidesB);

        bool areEqual = true;
        for (int i = 0; i < sidesA.Length; i++)
        {
            if (Mathf.Abs(sidesA[i] - sidesB[i]) > 0.1f) // Ανοχή για σφάλματα
            {
                areEqual = false;
                break;
            }
        }

        if (areEqual)
        {
            resultText.text = "Τα τρίγωνα είναι ίσα!";
            resultText.color = Color.green;
        }
        else
        {
            resultText.text = "Τα τρίγωνα δεν είναι ίσα.";
            resultText.color = Color.red;
        }
    }

    private float[] CalculateSides(Transform[] points)
    {
        float[] sides = new float[3];
        sides[0] = Vector3.Distance(points[0].position, points[1].position);
        sides[1] = Vector3.Distance(points[1].position, points[2].position);
        sides[2] = Vector3.Distance(points[2].position, points[0].position);
        return sides;
    }
}
