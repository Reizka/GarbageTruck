using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private int totalScore;
    private float timer;

    private bool pause;

    [SerializeField]
    private Text UIscore;
    [SerializeField]
    private Text UItimer;
    [SerializeField]
    private float levelDuration;


    private CameraScroller camMovement;

    private int[][] errors;

    public GameObject street, street_middle, pavement;
    public int height_y = 8;
    public int width_x = 70;
    private Transform streetholder;
    // Use this for initialization

    void Start()
    {
        pause = false;
        camMovement = GameObject.FindWithTag("MainCamera").GetComponent<CameraScroller>();
        errors = new int[4][];
        StartLevel();
    }

	void StartLevel () 
    {
        StreetSetup();
    
        timer = levelDuration;
        totalScore = 0;
        PrepareGarbageNotShown();
    }


	// Update is called once per frame
	void Update ()
    {
		if (!pause)
        {
            if (timer > 0f)
            {
                timer -= Time.deltaTime;
                if (timer < 0f)
                    timer = 0f;
            }
                
            
            UItimer.text = timer.ToString();



            UIscore.text = "SCORE: "+ totalScore.ToString();

            //Means that level Ended
            if (timer <= 0)
            {
                camMovement.SetRolling(false);
            }
        }
	}

    public void Pause(bool paused)
    {
        pause = true;
    }

    public void ManipulateScore(int val)
    {
        totalScore += val;
    }


    //if the garbage is before the truck, transforms it collider in trigger so it can pass through the truck
    //the collider will be turned into collision again (!trigger) at GarbageScoring
    private void TransformColliderInTrigger(GameObject[] allGarbage)
    {
        foreach (GameObject garbage in allGarbage)
        {
            if (garbage.transform.position.x <= -6f)
            {
                garbage.GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }
    }



    public void PrepareGarbageNotShown()
    {
        GameObject[] allGarbage = GameObject.FindGameObjectsWithTag("GarbageCartoon");

        TransformColliderInTrigger(allGarbage);

        allGarbage = GameObject.FindGameObjectsWithTag("GarbageGeneric");

        TransformColliderInTrigger(allGarbage);

        allGarbage = GameObject.FindGameObjectsWithTag("GarbagePlastic");

        TransformColliderInTrigger(allGarbage);

        

    }

    //translates the errors into a matrix
    public void RegisterError(string tagBin, string tagObj)
    {
        int binIdx = 0;
        int garbageIdx = 0;
        switch (tagBin)
        {
            case "GarbageCartoon":
                binIdx = 0;
                break;

            case "GarbageGeneric":
                binIdx = 1;
                break;

            case "GarbagePlastic":
                binIdx = 2;
                break;

            case "GarbageGlass":
                binIdx = 3;
                break;
        }
        switch (tagObj)
        {
            case "GarbageCartoon":
                garbageIdx = 0;
                break;

            case "GarbageGeneric":
                garbageIdx = 1;
                break;

            case "GarbagePlastic":
                garbageIdx = 2;
                break;

            case "GarbageGlass":
                garbageIdx = 3;
                break;
        }

        errors[binIdx][garbageIdx]++;
    }



    void StreetSetup()
    {
        //Setting room size
        height_y = 3;
        width_x = 70;
    

        for (int x = -71; x < width_x + 1; x++)
        {
            for (int y = -3; y < height_y + 1; y++)
            {
                GameObject toInstantiate;
                float mid = y / 2;
                if (y == mid)
                {
                    toInstantiate = street_middle;
                }
                else {
                    toInstantiate = street;
                }
                
                if (x == -71 || x == width_x || y == -4 || y == height_y)
                {
                    toInstantiate = pavement;
                }

                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(streetholder);
                
            }
        }
    }

}
