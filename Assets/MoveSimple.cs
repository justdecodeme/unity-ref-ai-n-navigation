using UnityEngine;

public class MoveSimple : MonoBehaviour {

    public Vector3 goal = new Vector3(5, 0, 4);
    public float speed = 1f;

    private void LateUpdate() {
        Debug.DrawRay(transform.position, goal.normalized * 5f, Color.red);
        transform.Translate(goal.normalized * speed * Time.deltaTime);
    }
}
