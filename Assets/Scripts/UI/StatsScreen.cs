using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsScreen : MonoBehaviour {

    public GameObject objRight;

    [SerializeField]
    private Text rightTable;
    [SerializeField]
    private Text missedTable;



    // Use this for initialization
    void Start ()
    {
        rightTable.text = "";
        missedTable.text = "";
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
        Debug.Log("preparing");

        rightTable.text = "";
        missedTable.text = "";

        //display Rights
        for (int i = 0; i < rights.Length; i++)
        {
            //this means that category existed ingame
           if ((rights[i] > 0) || (missed[i] > 0))
            {
                rightTable.text = rightTable.text + GetName(i) + ": " + rights[i].ToString() + "; ";
                /*
                GameObject objRightClone = Instantiate(objRight);
                objRight.GetComponent<ObjStatsCorrect>().SetValue(rights[i].ToString());
                objRight.GetComponent<ObjStatsCorrect>().SetNameCat(GetName(i));
                objRightClone.transform.parent = rightTable.transform;
                */
            }

        }

        //display Missed
        for (int i = 0; i < missed.Length; i++)
        {
            //this means that category existed ingame
            if ((rights[i] > 0) || (missed[i] > 0))
            {
                missedTable.text = missedTable.text + GetName(i) + ": " + missed[i].ToString() + "; ";
                /*
                GameObject objRightClone = Instantiate(objRight);
                objRight.GetComponent<ObjStatsCorrect>().SetValue(missed[i].ToString());
                objRight.GetComponent<ObjStatsCorrect>().SetNameCat(GetName(i));
                objRightClone.transform.parent = missedTable.transform;
                */
            }

        }

    }





}
