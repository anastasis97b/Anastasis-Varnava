using UnityEngine;

public class TriangleDrawer : MonoBehaviour
{
    public Transform pointA; // Σύνδεσε το PointA
    public Transform pointB; // Σύνδεσε το PointB
    public Transform pointC; // Σύνδεσε το PointC

    private LineRenderer lineRenderer;

    void Start()
    {
        // Πάρε το Line Renderer από το GameObject
        lineRenderer = GetComponent<LineRenderer>();

        // Ορισμός σημείων
        lineRenderer.positionCount = 4; // Τρία σημεία + 1 για κλείσιμο του τριγώνου

        lineRenderer.SetPosition(0, pointA.position); // Σημείο A
        lineRenderer.SetPosition(1, pointB.position); // Σημείο B
        lineRenderer.SetPosition(2, pointC.position); // Σημείο C
        lineRenderer.SetPosition(3, pointA.position); // Επιστροφή στο A για κλείσιμο
    }
}
