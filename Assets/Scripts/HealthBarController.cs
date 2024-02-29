using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Control Healthbar prefab
/// </summary>
public class HealthBarController : MonoBehaviour
{
    // Rect transform of the size-changing bar
    private RectTransform innerRect;
    private float maxWidth = 0.0f;
    // The edge the health bar is anchored at (Right or Left)
    [SerializeField] private RectTransform.Edge anchoredEdge;
    public float testFill;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize members
        RectTransform outerRect = gameObject.GetComponent<RectTransform>();
        if (!outerRect)
            throw new System.Exception("No health bar detected!");
        maxWidth = outerRect.rect.width;
        innerRect = transform.Find("Bar").gameObject.GetComponent<RectTransform>();
        if (!innerRect)
            throw new System.Exception("No health bar detected!");
        if (anchoredEdge != RectTransform.Edge.Left
                && anchoredEdge != RectTransform.Edge.Right)
            throw new System.Exception("Healthbar must be anchored on left or right.");

        SetBarFill(1f);
    }

    /// <summary>
    /// Set healthbar fill ratio.
    /// </summary>
    /// <param name="fillRatio">
    /// A value between 0 (empty) and 1 (full) that determines
    /// how much the bar is filled.
    /// </param>
    public void SetBarFill(float fillRatio)
    {
        if (fillRatio > 1 || fillRatio < 0)
            Debug.Log("Warning: Fill ratio is out of bounds.");
        SetBarWidth(maxWidth * fillRatio);
    }

    private void SetBarWidth(float width)
    {
        innerRect.SetInsetAndSizeFromParentEdge(anchoredEdge, 0f, width);
    }
}
