using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public UnityEngine.UI.Text points;
    public UnityEngine.UI.Text highScore;

	// Use this for initialization
	void Start () {

        points.text = PlayerPrefs.GetInt("points").ToString();
        highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene("InfiniteRunner");

        }
    }
}
