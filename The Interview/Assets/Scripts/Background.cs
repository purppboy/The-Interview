using UnityEngine;
using UnityEngine.UI;


public class Background : MonoBehaviour
{
    public new Camera camera;
    
    // Start is called before the first frame update
    void Start()
    {
        var allImages = Resources.FindObjectsOfTypeAll<Image>();

        foreach (var image in allImages)
        {
            image.alphaHitTestMinimumThreshold = 0.4f;
        }
        GenerateCollidersAcrossScreen();
    }

    private void GenerateCollidersAcrossScreen()
    {
        Vector2 lDCorner = camera.ViewportToWorldPoint(new Vector3(0, 0f, camera.nearClipPlane));
        Vector2 rUCorner = camera.ViewportToWorldPoint(new Vector3(1f, 1f, camera.nearClipPlane));
        Vector2[] colliderpoints;

        EdgeCollider2D upperEdge = new GameObject("upperEdge").AddComponent<EdgeCollider2D>();
        colliderpoints = upperEdge.points;
        colliderpoints[0] = new Vector2(lDCorner.x, rUCorner.y);
        colliderpoints[1] = new Vector2(rUCorner.x, rUCorner.y);
        upperEdge.points = colliderpoints;

        EdgeCollider2D lowerEdge = new GameObject("lowerEdge").AddComponent<EdgeCollider2D>();
        colliderpoints = lowerEdge.points;
        colliderpoints[0] = new Vector2(lDCorner.x, lDCorner.y);
        colliderpoints[1] = new Vector2(rUCorner.x, lDCorner.y);
        lowerEdge.points = colliderpoints;

        EdgeCollider2D leftEdge = new GameObject("leftEdge").AddComponent<EdgeCollider2D>();
        colliderpoints = leftEdge.points;
        colliderpoints[0] = new Vector2(lDCorner.x, lDCorner.y);
        colliderpoints[1] = new Vector2(lDCorner.x, rUCorner.y);
        leftEdge.points = colliderpoints;

        EdgeCollider2D rightEdge = new GameObject("rightEdge").AddComponent<EdgeCollider2D>();

        colliderpoints = rightEdge.points;
        colliderpoints[0] = new Vector2(rUCorner.x, rUCorner.y);
        colliderpoints[1] = new Vector2(rUCorner.x, lDCorner.y);
        rightEdge.points = colliderpoints;
    }
}