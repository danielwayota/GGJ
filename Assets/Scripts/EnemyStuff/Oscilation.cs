using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscilation : MonoBehaviour
{
    public Vector2 oscilationVector;

    [Range(0.1f, 10f)]
    public float oscilationSpeed = 1f;

    private float angle;
    private Vector3 anchorPoint;

    // ==========================================
    void Start()
    {
        this.angle = 0;

        this.anchorPoint = this.transform.position;
    }

    private const float TAU = Mathf.PI * 2;

    // ==========================================
    void Update()
    {
        this.angle += Time.deltaTime * this.oscilationSpeed;

        if (this.angle > TAU)
        {
            this.angle -= TAU;
        }

        float x = Mathf.Cos(this.angle) * this.oscilationVector.x;
        float y = Mathf.Sin(this.angle) * this.oscilationVector.y;

        Vector3 offset = new Vector3(x, y);

        this.transform.position = this.anchorPoint + offset;
    }
}

