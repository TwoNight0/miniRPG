using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UnitStat : characterData
{
    public static UnitStat instance;

    public UnitStat()
    {
        

    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        InitStat();
    }

    [SerializeField] private int InitStatPoint = 5;

    public new Racial racial;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public override void Move()
    {
        throw new System.NotImplementedException();
    }

    public override void Skill_A()
    {
        throw new System.NotImplementedException();
    }

    public override void Skill_B()
    {
        throw new System.NotImplementedException();
    }

    public override void Skill_C()
    {
        throw new System.NotImplementedException();
    }

    private void InitStat()
    {
        //초기 스탯 추가
        while (InitStatPoint > 0)
        {
            int r = UnityEngine.Random.Range(0, 5);

            switch (r)
            {
                case 0:
                    Strength++;
                    InitStatPoint--;
                    break;
                case 1:
                    Fitness++;
                    InitStatPoint--;
                    break;
                case 2:
                    Nimble++;
                    InitStatPoint--;
                    break;
                case 3:
                    Intelligence++;
                    InitStatPoint--;
                    break;
                case 4:
                    Accuracy++;
                    InitStatPoint--;
                    break;
            }

        }


        //종족 선택
        int len = System.Enum.GetValues(typeof(Racial)).Length;
        int IntRacial = UnityEngine.Random.Range(0, len);
        // 근건 건강 민첩 지능 명중

        //오크 : 근력 + 4, 건강 + 3, 민첩 -1, 지능 - 2 -> +4
        //엘프 : 지능 + 4, 민첩 + 1, 건강 - 1 -> +4
        //인간 : 건강 제외 올 스탯 +1 -> +4
        //드워프 : 근력 + 2, 지능 + 1, 건강 + 3, 민첩 -2, -> +4 
        //수인 : 민첩 + 4, 명중 +1, 지능 -1 -> +4

        //종족에 해당되는 스택 수정 
        switch (IntRacial)
        {
            case 0:
                //오크
                Strength += 4;
                Fitness += 3;
                Intelligence -= 2;
                Nimble -= 1;

                //종족
                racial = Racial.Orc;
                break;
            case 1:
                //엘프
                Intelligence += 4;
                Nimble += 1;
                Fitness -=1;

                racial = Racial.Orc;
                break;
            case 2:
                //인간
                Strength += 1;
                Nimble += 1;
                Intelligence += 1;
                Accuracy += 1;

                racial = Racial.Human;
                break;
            case 3:
                //드워프
                Strength += 2;
                Intelligence += 1;
                Fitness += 3;
                Nimble -= 2;

                racial = Racial.Dwarf;
                break;
            case 4:
                Nimble += 4;
                Intelligence -= 1;
                Accuracy +=1;

                racial = Racial.Mammon;
                break;
        }

        Debug.Log("종족 : " + (Racial)IntRacial);

        Debug.Log("근력 : " + Strength);
        Debug.Log("건강 : " + Fitness);
        Debug.Log("민첩 : " + Nimble);
        Debug.Log("지능 : " + Intelligence);
        Debug.Log("명중 : " + Accuracy);

    }
}
