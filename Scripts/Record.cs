using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Record : MonoBehaviour
{

    public Text _infoTextRecord;
    public int record;
    private int scoremod;


    // Start is called before the first frame update
    void Start()
    {
        _infoTextRecord.text = "";
           _infoTextRecord.text = "" + record.ToString();
      

    }

    // Update is called once per frame
    void Update()
    {

    //    scoremod = GetComponent <GameControl>().score;
        //int record = Record;
        if (scoremod > record)
        {
            PlayerPrefs.SetInt("sevescore", scoremod);
            PlayerPrefs.Save();
            Debug.Log("Save");
        }

        record = PlayerPrefs.GetInt("sevescore");

    }
}
