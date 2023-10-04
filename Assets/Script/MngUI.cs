using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class MngUI : MonoBehaviour
{

    #region Script


    #endregion

    //test
    [SerializeField] private GameObject Panel_Inventory;
    [SerializeField] private GameObject PanelStat;
    [SerializeField] private GameObject PanelChactor;

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
            PanelChactor.SetActive(!PanelChactor.activeSelf);

            //스탯창 켜고
            PanelStat.SetActive(!PanelStat.activeSelf);

            //스크립트에서 함수를 가져와서 텍스트 할당해주고


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

        Debug.Log(UnitData_Racial);
        #endregion

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //stat indicate
    public void StatIndicate()
    {
        UnitData_Racial.text = UnitStat.instance.m_racial.ToString();


    }

}
