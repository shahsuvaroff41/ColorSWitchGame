using UnityEngine;

public class CameraFlw : MonoBehaviour
{
    public BallControll ballCntrl;
    public Transform ballTr, lowGrand;
#pragma warning disable IDE0051 // Remove unused private members
    void Start()
#pragma warning restore IDE0051 // Remove unused private members
    {

    }


#pragma warning disable IDE0051 // Remove unused private members
    void Update()
#pragma warning restore IDE0051 // Remove unused private members
    {
        if (ballTr.position.y > transform.position.y)
        { transform.position = new Vector3(transform.position.x, ballTr.position.y, transform.position.z); }
        else if (ballTr.position.y < lowGrand.position.y)
        { StartCoroutine(ballCntrl.WaitTillNew()); }
    }
    
}
