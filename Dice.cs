using UnityEngine;

public class Dice : MonoBehaviour
{
    public int DiceValue { get; private set; } = 0;

    void Update()
    {
        DiceValue = GetTopFace();
    }

    private int GetTopFace()
    {
        Vector3 up = transform.up;

        if (Vector3.Dot(up, Vector3.up) > 0.9f) return 1;
        if (Vector3.Dot(up, Vector3.down) > 0.9f) return 6;
        if (Vector3.Dot(up, Vector3.left) > 0.9f) return 4;
        if (Vector3.Dot(up, Vector3.right) > 0.9f) return 3;
        if (Vector3.Dot(up, Vector3.forward) > 0.9f) return 5;
        if (Vector3.Dot(up, Vector3.back) > 0.9f) return 2;

        return 0; // Αν δεν υπάρχει ξεκάθαρη πάνω πλευρά
    }
}
