using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class MngUI : MonoBehaviour
{
    public static MngUI instance;

    #region Script


    #endregion

    #region GameObject
    //팝업패널로 묶은다음 아래것들은 팝업패널에서 찾도록만들 것
    [SerializeField] private GameObject PanelPopup;
    [SerializeField] private GameObject Panel_Inventory;
    [SerializeField] private GameObject PanelStat;
    [SerializeField] private GameObject PanelChactor;

    [SerializeField] public GameObject PanelLeft;
    [SerializeField] public GameObject PanelRight;



    #endregion
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

    #region Text
    private TextMeshProUGUI UnitData_Racial;
    private TextMeshProUGUI UnitData_Strength;
    private TextMeshProUGUI UnitData_Fitness;
    private TextMeshProUGUI UnitData_Nimble;
    private TextMeshProUGUI UnitData_Intelligence;
    private TextMeshProUGUI UnitData_Accuracy;

    #endregion


   

    private void Awake()
    {
        initUI();
    }

    // Start is called before the first frame update
    void Start()
    {
        PanelStat.SetActive(false);

        PanelLeft.SetActive(false);
        PanelRight.SetActive(false);
        PanelPopup.SetActive(false);
    }

    /// <summary>
    /// initialize
    /// </summary>
    private void initUI()
    {
        //singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }


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
            PanelChactor.SetActive(!PanelChactor.activeSelf);

            //스탯창 켜고
            PanelStat.SetActive(!PanelStat.activeSelf);

            //스크립트에서 함수를 가져와서 텍스트 할당해주고
            StatIndicate();

        });
        #endregion

        //꺼져있어서 못찾네..?
        #region Text 할당
        UnitData_Racial = GameObject.Find("UnitData_Racial").GetComponent<TextMeshProUGUI>();
        UnitData_Strength = GameObject.Find("UnitData_Strength").GetComponent<TextMeshProUGUI>();
        UnitData_Fitness = GameObject.Find("UnitData_Fitness").GetComponent<TextMeshProUGUI>();
        UnitData_Nimble = GameObject.Find("UnitData_Nimble").GetComponent<TextMeshProUGUI>();
        UnitData_Intelligence = GameObject.Find("UnitData_Intelligence").GetComponent<TextMeshProUGUI>();
        UnitData_Accuracy = GameObject.Find("UnitData_Accuracy").GetComponent<TextMeshProUGUI>();

        //Debug.Log(UnitData_Racial);
        #endregion

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //stat indicate
    public void StatIndicate()
    {
        UnitData_Racial.text = "종족: " + UnitStat.instance.m_racial.ToString();
        UnitData_Strength.text = "근력 : " + UnitStat.instance.PubStrength.ToString();
        UnitData_Fitness.text = "건강 : " + UnitStat.instance.PubFitness.ToString();
        UnitData_Nimble.text = "민첩 : " + UnitStat.instance.PubNimble.ToString();
        UnitData_Intelligence.text = "지능 : " + UnitStat.instance.PubIntelligence.ToString();
        UnitData_Accuracy.text = "명중 : " + UnitStat.instance.PubAccuracy.ToString();

    }

}
