using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class OrbitVisualizer : MonoBehaviour
{
    public OrbitController orbitController; // Reference to your OrbitController script
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        DrawOrbit();
    }

    void DrawOrbit()
    {
        int points = 100; // Number of points on the circle
        lineRenderer.positionCount = points;
        float angleStep = 360f / points;

        for (int i = 0; i < points; i++)
        {
            float angle = i * angleStep * Mathf.Deg2Rad;
            float x = Mathf.Cos(angle) * orbitController.orbitRadius;
            float z = Mathf.Sin(angle) * orbitController.orbitRadius;
            lineRenderer.SetPosition(i, new Vector3(x, 0, z) + transform.position);
        }
    }
}
