using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameSceneController : MonoBehaviour {

    public PlayerController player;
    public Camera gameCamera;
    public GameObject[] blockPrefabs;
    public Text gameText;

    private float blockPointer;
    private float safeArea = 10;
    private bool isGameOver;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        while(player != null && blockPointer < player.transform.position.x + safeArea)
        {
            int blockIndex = Random.Range(0, blockPrefabs.Length);

            if(blockPointer < 25)
            {
                blockIndex = 0;
            }

            GameObject blockObject = GameObject.Instantiate<GameObject>(blockPrefabs[blockIndex]);
            blockObject.transform.SetParent(this.transform);
            BlockController block = blockObject.GetComponent<BlockController>();
            blockObject.transform.position = new Vector3(blockPointer + block.size/2, 0, 0);
            blockPointer += block.size;
        }
        if(player != null)
        {
            gameCamera.transform.position = new Vector3(player.transform.position.x, gameCamera.transform.position.y, gameCamera.transform.position.z);
            gameText.text = "Score : " + Mathf.Floor(player.transform.position.x);
        }
        else
        {
            if(!isGameOver)
            {
                isGameOver = true;
                gameText.text += "\nPress R to reset";

            }
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
	}
}
