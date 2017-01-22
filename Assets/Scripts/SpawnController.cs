using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

    public GameObject obstaclePrefab; // Obj to be spawned
    public float rateSpawn;
    private float currentTime;
    private int upOrDown;
    private float positionY;
    public float posA;
    public float posB;

    // Use this for initialization
    void Start () {
        currentTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
        if(currentTime >= rateSpawn){
            currentTime = 0;
            upOrDown = Random.Range(1, 100);
            if (upOrDown > 50){
                positionY = posA;
                //positionY = 0.30f;
            }
            else {
                positionY = posB;
                //positionY = -0.29f;
            }
            GameObject tempPrefab = Instantiate(obstaclePrefab) as GameObject;
            tempPrefab.transform.position = new Vector3(transform.position.x, 
                positionY, tempPrefab.transform.position.z);
            

        }


	}
}
