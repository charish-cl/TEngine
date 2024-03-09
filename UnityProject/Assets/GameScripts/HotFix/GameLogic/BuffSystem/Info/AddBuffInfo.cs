
using UnityEngine;

public struct AddBuffInfo
{
    //buff的model
    public GameObject model;
    
    //释放者
    public Entity caster;
    
    //目标
    public Entity target;
    
    //时间
    public float time;
    
    //层数
    public int count;
    
    //参数
    public object param;
}