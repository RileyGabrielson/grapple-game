using UnityEngine;

public class RotateForce : MonoBehaviour
{
    public Rigidbody2D rotationObject;
    public float torqueAmount;
    public float maxRotationalVelocity;

    public void RotateLeft()
    {
      if(Mathf.Abs(rotationObject.angularVelocity) < this.maxRotationalVelocity) 
        this.rotationObject.AddTorque(this.torqueAmount);
    }

    public void RotateRight()
    {
      if(Mathf.Abs(rotationObject.angularVelocity) < this.maxRotationalVelocity) 
        this.rotationObject.AddTorque(-1f * this.torqueAmount);
    }
}
