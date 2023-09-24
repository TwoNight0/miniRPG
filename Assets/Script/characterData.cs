using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CC 및 상태
public enum State
{
    Default,
    Stun,
    Immobilized,
    Move,
    Idle
}

public enum Racial
{
    //근 건 민 지 명

    //오크 : 근력 + 2, 건강 + 1, 지능 - 2, 명중 -1
    Orc,

    //엘프 : 지능 + 2, 건강 - 2
    Elf,

    //인간 : 추가 스탯 x 
    Human,

    //드워프 : 근력 + 1, 건강 + 1, 약한 민첩 -2, 
    Dwarf, 

    //수인 : 근력 +1, 민첩 + 2, 지능 -2, 명중 -1  
    Mammon,
}

public enum AttackType_player
{   
    Melee,//근접
    Range//원거리
}

public abstract class characterData : MonoBehaviour
{
    //캐릭터 닉네임
    protected string Name;
    //캐릭터 ID
    protected int characterID;

    //레벨
    protected int Level = 1;
    //경험치
    protected float LevelExp = 0.0f;
    //경험치 맥스
    protected float MaxLevelExp;

    //시야
    protected float RangeOfView;

    //체력
    protected float Hp;

    //최대체력
    protected float MaxHp;
    
    //기본 공격력
    protected float DmgPhysics = 20.0f;
    //주문력
    protected float DmgMagic = 0.0f;
    //방어력
    protected float DefPhysics = 10.0f;
    //마법방어력
    protected float DefMagic = 0.0f;
    //쿨타임 감소율
    protected float CoolDownRatio;

    //사거리
    protected int AttackRange;
    //공격속도
    protected float AttackSpeed;
    //치명타율
    protected float CriticalRatio = 0.0f;
    //흡혈
    protected float HpAbsorb = 0.0f;
    //최대마나
    protected int MaxMana;

    #region state

    //근력
    protected int Strength = 2;

    //건강
    protected int Fitness = 2;

    //민첩
    protected int Nimble = 2;

    //지능
    protected int Intelligence = 2;

    //명중
    protected int Accuracy = 2;

    #endregion



    //공격 타입
    protected AttackType_player attackType;

    //상태
    protected State state;

    protected Racial racial;
    private object cas;

    //기본 공격
    public abstract void Attack();

    //클릭 이동
    public abstract void Move();

    public virtual void LevelUp(int _level)
    {
        //200 300 400 250 300 ...
        MaxLevelExp = _level * 100.0f + 100.0f;
    }
    public abstract void Skill_A();
    public abstract void Skill_B();
    public abstract void Skill_C();

  

}
