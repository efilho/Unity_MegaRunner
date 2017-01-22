using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour {

    public Transform player;
    public Animator Animation;
    public Rigidbody2D playerRigidBody;
    public int jumpForce;
    public int walkDistance;

    //Slide
    public float timeTemp;
    public float slideTemp;

    public bool slide;

    //Colider
    public Transform colider;

    //Checkout the ground
    public Transform groundCheck;
    public bool grounded;
    public LayerMask isGround;

    //Audio
    public AudioSource sound;
    public AudioClip soundJump;
    public AudioClip soundDash;

    //Points
    public static int points;
    public Text txtPoints;

    // Use this for initialization
    void Start () {
        points = 0;
	}
	
	// Update is called once per frame
	void Update () {
        #region Walk Command
        if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") > 0) {
            player.position = new Vector3(player.position.x + 0.1f,
                player.position.y);
            //playerRigidBody.MovePosition(new Vector2(playerRigidBody.position.x + 1, 0));

            if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") < 0) {
                player.position = new Vector3(player.position.x - 0.1f,
                    player.position.y);
            }
            
        }
        #endregion

        #region Jump Command
        if (Input.GetButtonDown("Jump") && grounded) {
            playerRigidBody.AddForce(new Vector2(0, jumpForce));

            GetComponent<AudioSource>().PlayOneShot(soundJump);

            if (slide) {
                colider.position = new Vector3(colider.position.x,
                    colider.position.y + 0.3f, colider.position.z);
            }
            slide = false;
        }
        #endregion

        #region Slide Command
        if (Input.GetButtonDown("Slide") && grounded && !slide) {
            slide = true;
            timeTemp = 0;
            GetComponent<AudioSource>().PlayOneShot(soundDash);

            colider.position = new Vector3(colider.position.x
                , colider.position.y - 0.3f, colider.position.z);
        }

        if (slide == true) {
            //time.deltaTime calcula quanto tempo se passou entre cada frame
            timeTemp += Time.deltaTime;

            
            if (timeTemp >= slideTemp) {
                slide = false;
                colider.position = new Vector3(colider.position.x, 
                    colider.position.y + 0.3f, colider.position.z);
                
            }
        }
        #endregion

        #region Is Grounded
        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, isGround);


        #endregion

        Animation.SetBool("jump", !grounded);
        Animation.SetBool("slide", slide);

        #region Points Update
        txtPoints.text = points.ToString();
        //print(points);
        PlayerPrefs.SetInt("points", points);
        #endregion

    }

    void OnTriggerEnter2D(){

//        PlayerPrefs.SetInt("points", points);
        if (points > PlayerPrefs.GetInt("HighScore")) {
            PlayerPrefs.SetInt("HighScore", points);
        }
        SceneManager.LoadScene("GameOver");
    }


}
