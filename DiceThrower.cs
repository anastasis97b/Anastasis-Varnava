using UnityEngine;

public class DiceThrower : MonoBehaviour
{
    public Rigidbody dice1;
    public Rigidbody dice2;

    private bool diceThrown = false;

    public void ThrowDice()
    {
        if (diceThrown) return; // Αν τα ζάρια έχουν ήδη ριχτεί, μην προχωράς
        diceThrown = true;

        // Εφαρμογή τυχαίων δυνάμεων στα ζάρια
        ThrowSingleDice(dice1);
        ThrowSingleDice(dice2);

        Invoke("ResetDice", 3f); // Επαναφορά για νέα ρίψη μετά από 3 δευτερόλεπτα
    }

    void ThrowSingleDice(Rigidbody dice)
    {
        dice.transform.position = new Vector3(Random.Range(-2, 2), 2, Random.Range(-2, 2));
        dice.transform.rotation = Random.rotation;
        dice.velocity = Vector3.zero;
        dice.angularVelocity = Vector3.zero;
        dice.AddForce(Vector3.up * Random.Range(500, 700));
        dice.AddTorque(Random.insideUnitSphere * 500);
    }

    void ResetDice()
    {
        diceThrown = false; // Επαναφορά για νέα ρίψη
    }
}
