using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public Action MouseClicked;
    public Action<Vector2> MouseMoved;
   
    public void OnMouseClicked(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            MouseClicked?.Invoke();
            Debug.Log("Å¬¸¯µÊ");
        }
    }

    public void OnMouseMoved(InputAction.CallbackContext context)
    {
        MouseMoved?.Invoke(Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>()));
    }

}
