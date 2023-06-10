using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public bool collided;
    public static int collisionCounter; // Counter for enemy collisions
    public GameObject bird;
    public GameObject Winpanel;
    public void Release()
    {
        PathPoints.instance.Clear();
        StartCoroutine(CreatePathPoints());
    }
    private void Start()
    {
        collisionCounter = PlayerPrefs.GetInt("CollisionCounter");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collided = true;
        if (bird.tag == collision.gameObject.tag)
        {
            Destroy(collision.gameObject);
           
            collisionCounter++; // Increment the collision counter
            if (collisionCounter > 4)
            {
                collisionCounter = 1; // Reset the collision counter to 0
            }
           

            PlayerPrefs.SetInt("CollisionCounter", collisionCounter); // Save the updated counter value
            PlayerPrefs.Save(); // Save the PlayerPrefs data
          

            // Log the collision counter value
            Debug.Log("Collision Counter: " + collisionCounter);
        }
        Invoke("DestroyBird", 2f);
    }

    void DestroyBird()
    {
        gameObject.tag = "NewTag";
        Destroy(gameObject);
        // Access collisionCounter here or pass it to another method as needed

    }

    IEnumerator CreatePathPoints()
    {
        while (true)
        {
            if (collided) break;
            PathPoints.instance.CreateCurrentPathPoint(transform.position);
            yield return new WaitForSeconds(PathPoints.instance.timeInterval);
        }
    }
}
