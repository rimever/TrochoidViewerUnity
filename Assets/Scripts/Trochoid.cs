using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(LineRenderer))]
public class Trochoid : MonoBehaviour
{
    private LineRenderer _lineRenderer;

    private Vector3[] vertices;

    private int verticesNumber = 2000;

    // Start is called before the first frame update
    void Start()
    {
        InitializeRenderer();
        InitializeVertices();
        Create(5, 3, 5);
        SetVertices();
    }

    private void SetVertices()
    {
        _lineRenderer.positionCount = vertices.Length;
        _lineRenderer.SetPositions(vertices);
    }

    private void Create(float rc, float rm, float rd)
    {
        var theta = Mathf.PI / 45f;
        var r1 = rc - rm;
        var r2 = r1 / rm;
        for (int i = 0; i < vertices.Length; i++)
        {
            var x = r1 * Mathf.Cos(theta * i) + rd * Mathf.Cos(r2 * theta * i);
            var y = r1 * Mathf.Sin(theta * i) - rd * Mathf.Sin(r2 * theta * i);
            vertices[i] = new Vector3(x, y, 0);
        }
    }

    private void InitializeVertices()
    {
        vertices = new Vector3[verticesNumber];
    }

    private void InitializeRenderer()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Change();
        }
    }

    private void Change()
    {
        Create(Random.Range(1f, 7f), Random.Range(1f, 7f), Random.Range(1f, 7f));
        SetVertices();
        _lineRenderer.startColor = new Color(Random.Range(0.1f, 0.7f), Random.Range(0.1f, 0.7f),
            Random.Range(0.1f, 0.7f), 0.75f);
        _lineRenderer.endColor = _lineRenderer.startColor;
    }
}