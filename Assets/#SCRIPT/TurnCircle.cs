using UnityEngine;

public class TurnCircle : MonoBehaviour
{
    public float turnSpeed;

#pragma warning disable IDE0051 // Remove unused private members
    void Update()
#pragma warning restore IDE0051 // Remove unused private members
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
