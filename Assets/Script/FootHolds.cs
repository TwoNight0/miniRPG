using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootHolds : MonoBehaviour
{
    /// <summary>
    /// 맨위 x : 4.15 / z : 2.5
    /// 간격 가로 : 0.75 / 세로 : 0.7
    /// 총갯수 : 12 x 8 = 96개의 발판
    /// </summary>

    [SerializeField] private GameObject foothold;
    private GameObject foothold_parent;
    private List<GameObject> list_foothold;

    [Header("Max")]
    public int row = 12;
    public int col = 8;

    //조정
    [Header("Gap")]
    public float rowGap = 0.75f;
    public float colGap = 0.72f;

    private Vector3 firstFootholdpos;

    //만들고 리스트에 넣어서 관리 하고 필요시 메테리얼 변경해서 사용

    // Start is called before the first frame update
    void Start()
    {
        // 해상도를 픽셀로 고정시키는
        Screen.SetResolution(1920, 1080, true);

        // 해상도를 비율로 고정시키는
        


        footholdInit();
    }

    public void footholdInit()
    {
        list_foothold = new List<GameObject>();

        foothold_parent = GameObject.Find("FootHolds");

        firstFootholdpos = new Vector3(-4.15f, 0, 2.5f);

        int totalFoothold = row * col;
        for (int i = 0; i < totalFoothold; i++)
        {
            GameObject tile = Instantiate(foothold, foothold_parent.transform);
            tile.transform.position = new Vector3(firstFootholdpos.x + ((i % row) * rowGap), 0, firstFootholdpos.z - ((i / row) * colGap));
            list_foothold.Add(tile);
        }
    }

    private void printList(int _total, List<GameObject> _list)
    {
        for(int i = 0; i < _total; i++)
        {
            Debug.Log( i + " : " +_list[i].transform.position);
        }
    }

}
