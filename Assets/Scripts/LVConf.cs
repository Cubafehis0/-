﻿using UnityEngine;
using UnityEngine.UI;

public class LVConf : MonoBehaviour
{

    public int LV;
    public Text LVNumber;
    public GameObject LVLock;
    public GameObject[] StarFronts;
    public GameObject Aureole;
    public Transform PersonConf;
    public GameObject PersonConf2;

    // Use this for initialization
    void Start()
    {
        LVNumber.text = LV.ToString();
        //亮光圈的关卡
        int GateLevel = PlayerPrefs.GetInt("DB_GateLevel");
        if (GateLevel == LV)
        {
            Aureole.SetActive(true);
            Instantiate(PersonConf2, PersonConf);
        }
        if (GateLevel >= LV)
        {
            LVLock.SetActive(false);
            bool LVStarNumber1 = KeyValue.GetBool("DB_LV" + LV + "StarNumber1");
            bool LVStarNumber2 = KeyValue.GetBool("DB_LV" + LV + "StarNumber2");
            bool LVStarNumber3 = KeyValue.GetBool("DB_LV" + LV + "StarNumber3");
            if (LVStarNumber1)
            {
                StarFronts[0].SetActive(true);
            }
            if (LVStarNumber2)
            {
                StarFronts[1].SetActive(true);
            }
            if (LVStarNumber3)
            {
                StarFronts[2].SetActive(true);
            }
        }
        else
        {

        }

    }
    // Update is called once per frame
    void Update()
    {

    }
}
