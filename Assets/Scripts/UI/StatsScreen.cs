using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsScreen : MonoBehaviour {

    public GameObject objRight;

    [SerializeField]
    private GameObject rightTable;
    [SerializeField]
    private GameObject missedTable;



    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    private string GetName(int idx)
    {
        switch (idx)
        {
            case 0:
                return "PAPER";


            case 1:
                return "GENERIC";


            case 2:
                return "PLASTIC";


            case 3:
                return "GLASS";

        }
        return null;
    }

    public void Prepare(int [,] errors, int[] rights, int[] missed)
    {
        //display Rights
        for (int i = 0; i < rights.Length; i++)
        {
            //this means that category existed ingame
           if ((rights[i] > 0) || (missed[i] > 0))
            {
                GameObject objRightClone = Instantiate(objRight);
                objRight.GetComponent<ObjStatsCorrect>().SetValue(rights[i].ToString());
                objRight.GetComponent<ObjStatsCorrect>().SetNameCat(GetName(i));
                objRightClone.transform.parent = rightTable.transform;
            }

        }

        //display Rights
        for (int i = 0; i < missed.Length; i++)
        {
            //this means that category existed ingame
            if ((rights[i] > 0) || (missed[i] > 0))
            {
                GameObject objRightClone = Instantiate(objRight);
                objRight.GetComponent<ObjStatsCorrect>().SetValue(missed[i].ToString());
                objRight.GetComponent<ObjStatsCorrect>().SetNameCat(GetName(i));
                objRightClone.transform.parent = missedTable.transform;
            }

        }

    }





}
