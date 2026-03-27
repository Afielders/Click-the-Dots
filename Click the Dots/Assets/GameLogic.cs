using System.Threading;
using UnityEngine;
using TMPro;

public class GameLogic : MonoBehaviour
{
    public Camera Cam;

    // Spawning Dots
    public GameObject dot;
    public float time_between_spawns = 1f;
    private float dot_timer = 0.0f;


    //Score
    private int score = 0;
    public TMP_Text score_text;

    //GameTimer
    private float game_timer =60; //In Seconds.
    public TMP_Text game_timer_text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Start timeer.
        dot_timer = 0.5f;
        //Set the default text at the beginning of the game.
        score_text.text = "Score: 0";
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
                //Add the clicked dots point value.
                score += hit.collider.gameObject.GetComponent<Dot>().point_value;

                //Set the score_text's text string to the current score value.
                score_text.text = "Score: " + score;

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
        GameObject new_dot = Instantiate(dot);
        // Find a random x/y position in screen space.
        int x_pos = Random.Range(0, Cam.scaledPixelWidth);
        int y_pos = Random.Range(0, Cam.scaledPixelHeight);
        // Convert the position to world space.
        Vector3 spawn_point = new Vector3(x_pos, y_pos, 0);
        spawn_point = Cam.ScreenToWorldPoint(spawn_point);
        spawn_point.z = 0;

        //Move new dot to new spawn point.
        new_dot.transform.position = spawn_point;
    }
}
