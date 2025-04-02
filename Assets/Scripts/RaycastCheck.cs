using UnityEngine;
using UnityEngine.EventSystems;

public class RaycastCheck : MonoBehaviour
{
    public static LayerMask ObstacleMask;
    public static Vector3 ObstacleTo(Vector3 origin,Vector3 direction)
    {
        RaycastHit hit;
        if (Physics.Raycast(origin, direction, out hit, 1000, ObstacleMask))
        {
            return (hit.point);
        }
        else 
        {
            return (Vector3.zero);
        }
    }

}
