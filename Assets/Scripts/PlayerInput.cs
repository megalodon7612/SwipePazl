using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public static UnityAction<Vector3> OnChoiceDirection; 
    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            OnChoiceDirection?.Invoke(Vector3.right);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            OnChoiceDirection?.Invoke(Vector3.left);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            OnChoiceDirection?.Invoke(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            OnChoiceDirection?.Invoke(Vector3.back);
        }
    }
}