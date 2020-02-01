using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    private void Update()
    {
        if (this.target == null)
            return;

        this.transform.position = Vector3.Lerp(this.transform.position, this.target.position + offset, Time.deltaTime);
    }
}