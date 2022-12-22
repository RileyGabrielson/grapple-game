using UnityEngine;

public class GrappleHook : MonoBehaviour
{
  public GameObject hookIndicator;
  public LineRenderer rope;
  public Rigidbody2D origin;
  public float range;
  public float pullForce;

  private Vector2 direction;
  private Vector2 pullPosition;
  private bool pulling = false;

  public void Pull() {
    RaycastHit2D hit = this.SendRaycast();
    if(hit && !pulling) this.HandleStartPull(hit);
  }

  public void StopPull() {
    this.pulling = false;
    this.rope.gameObject.SetActive(false);
  }

  private void HandleStartPull(RaycastHit2D hit) {
    this.pulling = true;
    this.pullPosition = hit.point;
    this.rope.gameObject.SetActive(true);
  }

  void Update() {
    this.UpdateIndicator();
    if(this.pulling) this.MoveToPullPosition();
    if(Input.GetMouseButtonDown(0)) this.Pull();
    if(Input.GetMouseButtonUp(0)) this.StopPull();
  }

  void MoveToPullPosition() {
    Vector2 originPosition = this.origin.transform.position;
    Vector2 force = (this.pullPosition - originPosition).normalized * this.pullForce;
    this.origin.AddForce(force);

    Vector3[] positions = new Vector3[2];
    positions[0] = this.origin.transform.position;
    positions[1] = this.pullPosition;
    this.rope.SetPositions(positions);
  }

  private void UpdateIndicator() {
    this.UpdateDirection();
    RaycastHit2D hit = this.SendRaycast();
    if(hit && !this.pulling) this.ShowIndicator(hit);
    else this.HideIndicator();
  }

  private void UpdateDirection() {
    Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    this.direction = worldPosition - new Vector2(this.origin.transform.position.x, this.origin.transform.position.y);
  }

  private RaycastHit2D SendRaycast() {
    LayerMask mask = LayerMask.GetMask("Terrain");
    RaycastHit2D hit = Physics2D.Raycast(this.origin.transform.position, this.direction, this.range, mask);
    return hit;
  }

  private void ShowIndicator(RaycastHit2D hit) {
    this.hookIndicator.SetActive(true);
    this.hookIndicator.transform.position = hit.point;
  }

  private void HideIndicator() {
    this.hookIndicator.SetActive(false);
  }
}
