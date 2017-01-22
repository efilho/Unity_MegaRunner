using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MoveObjects : MonoBehaviour {

    public GameObject Player;
    private bool pontuado;
    public static float speed;
    private float x;
    private int pointsCheckpoint;
    private int points;
    private float speedUpdate;
    private bool speedUp;
    

    // Use this for initialization
    void Start () {
        Player = GameObject.Find("Player") as GameObject;
        speed = -2.0f - (PlayerPrefs.GetInt("points") * 0.1f);
        
        
    }
	
	// Update is called once per frame
	void Update () {
        PlayerPrefs.SetFloat("speed", speed);

        x = transform.position.x;
        // DeltaTime = diferença de tempo entre um frame e outro;
        x += speed * Time.deltaTime - speedUpdate;

        transform.position = new Vector3(x, transform.position.y, transform.position.z);

        if (x <= -5.60f) {
            Destroy(transform.gameObject);
        }

        if (x < Player.transform.position.x && pontuado == false){
            pontuado = true;
            speedUp = false;
            playerController.points++;
            //print(speed);
        }
    
    }
    
}
