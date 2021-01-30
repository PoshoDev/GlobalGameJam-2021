using UnityEngine;

public class ShadowMovement : MonoBehaviour
{
    void Update()
    {
        transform.eulerAngles = new Vector3(90f,transform.parent.transform.eulerAngles.y,transform.parent.transform.eulerAngles.z);
    }
}
