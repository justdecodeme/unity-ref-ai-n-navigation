using UnityEngine;

public class MoveToGoal : MonoBehaviour {

    // Object speed
    public float speed = 2.0f;
    // Accuracy
    public float accuracy = 0.01f;
    // Object target
    public Transform goal;

    // Update is called once per frame
    void LateUpdate() {

        // Calculate the facing direction
        transform.LookAt(goal.position);

        // Find the the direction vector
        Vector3 direction = goal.position - transform.position;

        // Draw debug ray in the direction your object is facing
        Debug.DrawRay(transform.position, direction, Color.red);

        // Check how close you character is to the target
        if (direction.magnitude > accuracy) {

            // Move the Object
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }
    }
}
