using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float moveSpeed;

    public bool isMoving;

    public Vector2 input;

    private void Update()
    {
        if (!isMoving)  // Correcting the variable name from `inMoving` to `isMoving`
        {
            // Correcting `inout` to `input`
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            
            // Use a small epsilon to check if input is close to zero
            if (input != Vector2.zero)
            {
                // Calculate the target position
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                // Start the movement coroutine
                StartCoroutine(Move(targetPos));
                
                // Set isMoving to true
                isMoving = true;
            }
        }
    }

    // The targetPos parameter should be a Vector3
    IEnumerator Move(Vector3 targetPos)
    {
        // The correct spelling is sqrMagnitude, not sqeMagnitude
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null; // Yielding to allow other processes to run
        }
        
        // After movement is complete, set the final position
        transform.position = targetPos;
        
        // Set isMoving to false
        isMoving = false;
    }
}
