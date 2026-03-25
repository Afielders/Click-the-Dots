using System.Threading;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public Camera Cam;

    // Spawning Dots
    public GameObject dot;
    public float time_between_spawns = 1f;
    public float dot_timer = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Start timeer.
        dot_timer = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if left mouse button was pressed.
        if(Input.GetMouseButtonDown(0))
        {
            //Convert the mouse position from screen space to world space.
            Vector2 worldpoint = Cam.ScreenToWorldPoint(Input.mousePosition);

            //Shoot out a ray at the world point and store in hit.
            RaycastHit2D hit = Physics2D.Raycast(worldpoint, Vector2.zero);

            if(hit.collider != null)
            {
                //If so destroy the game object that has the collider.
                Destroy(hit.collider.gameObject);
            }
        }


        //Spawning Dots
        //Make the timer count down.
        dot_timer -= Time.deltaTime;

        // Once the timer counted down...
        if(dot_timer <= 0)
        {
            //Rest the timer.
            dot_timer = time_between_spawns;

            //Spawn a dot.
            SpawnDot();
        }

    }

    private void SpawnDot()
    { 
    
    }
}
