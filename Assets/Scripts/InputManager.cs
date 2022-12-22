using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent onLeft;
    public UnityEvent onRight;
    // Update is called once per frame
    void Update()
    {
      if(Input.GetKey(KeyCode.A)) this.onLeft.Invoke();
      if(Input.GetKey(KeyCode.D)) this.onRight.Invoke();
    }
}
