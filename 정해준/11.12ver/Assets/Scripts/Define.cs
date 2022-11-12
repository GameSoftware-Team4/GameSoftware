using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum WorldObject //오브젝트들의 속성을 구분하기 위한 종류를 나열
    { 
        Unknown,
        Player,
        Monster
    }

    public Define.WorldObject returnType(WorldObject type)
    {
        return type;
    }

}
