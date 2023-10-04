using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MngUI : MonoBehaviour
{

    #region Script


    #endregion

    //test
    public GameObject inventory;
    public GameObject stat;


    #region Button
    private Button BtnSetting;
    private Button BtnInventory;
    //스탯
    private Button BtnStat;



    //동료
    private Button BtnCrew_0;
    private Button BtnCrew_1;
    private Button BtnCrew_2;
    private Button BtnCrew_3;
    #endregion




    // Start is called before the first frame update
    void Start()
    {
        initUI();

    }

    /// <summary>
    /// initialize
    /// </summary>
    private void initUI()
    {
        //해상도 조정
        float targetRatio = 16.0f / 9.0f;
        float ratio = (float)Screen.width / (float)Screen.height;
        float scaleHeight = ratio / targetRatio;
        float fixedWidth = (float)Screen.width / scaleHeight;
        Screen.SetResolution((int)fixedWidth, Screen.height, true);


        #region 버튼 할당

        BtnSetting = GameObject.Find("BtnSetting").GetComponent<Button>();
        BtnSetting.onClick.AddListener(() => {
            //세팅창
        });

        BtnInventory = GameObject.Find("BtnInventroy").GetComponent<Button>();
        BtnInventory.onClick.AddListener(() => {
            //인벤토리

        });

        BtnStat = GameObject.Find("BtnStat").GetComponent<Button>();
        BtnStat.onClick.AddListener(() => {
            //캐릭터창 끄고


            //스탯창 켜고
            stat.SetActive(!stat.activeSelf);

            //스크립트에서 함수를 가져와서 텍스트 할당해주고

        });
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
