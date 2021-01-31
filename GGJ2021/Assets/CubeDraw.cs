using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDraw : MonoBehaviour
{
    [SerializeField] private Vector3 gridSize = default;
    // Start is called before the first frame update
    void OnDrawGizmos()
    {
        SnapToGrid();
    }

    // Update is called once per frame
    private void SnapToGrid()
    {
        transform.position = new Vector3(Mathf.RoundToInt(transform.position.x / gridSize.x)*gridSize.x,
                                        Mathf.RoundToInt(transform.position.y/ gridSize.y)*gridSize.y,
                                        Mathf.RoundToInt(transform.position.z/ gridSize.z)*gridSize.z);
                                    }
}
