using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define_jhj
{
    public enum WorldObject_jhj //오브젝트들의 속성을 구분하기 위한 종류를 나열
    { 
        Unknown,
        Player,
        Monster
    }

    public Define_jhj.WorldObject_jhj returnType(WorldObject_jhj type)
    {
        return type;
    }

}
