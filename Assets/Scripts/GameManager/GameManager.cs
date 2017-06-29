using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Sprite street, street_middle, pavement;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
/*
    void RoomSetup()
    {
        //Setting room size
        height_y = 8;
        width_x = room.Width;
        //setting tile gameobjects
        floorTile = Resources.Load("MainGame/" + room.FloorGameObjectName) as GameObject;
        outerWallTile = Resources.Load("MainGame/" + room.OuterwallGameObjectName) as GameObject;


        boardHolder = new GameObject("Room").transform;
        for (int x = -1; x < width_x + 1; x++)
        {
            for (int y = -1; y < height_y + 1; y++)
            {

                GameObject toInstantiate = floorTile;
                string oldTag = toInstantiate.gameObject.tag;
                if (x == -1 || x == width_x || y == -1 || y == height_y)
                {
                    toInstantiate = outerWallTile;
                }

                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(boardHolder);
                toInstantiate.gameObject.tag = oldTag;
            }
        }
    }*/
}
