using UnityEngine;
using Pathfinding;

public class ScanGraph : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AstarPath.active.Scan();  
    }
}
