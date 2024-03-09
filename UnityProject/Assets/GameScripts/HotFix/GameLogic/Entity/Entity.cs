
//实体基类

using System;
using System.Collections.Generic;
using TEngine;
using UnityEngine;

public class Entity:IMemory
{
    //实体ID
    public int ID;
    //Unity对象
    public GameObject RoleObject;
    //阵营
    public CampType Camp;
    
    //Buff列表List
    List<Buff> BuffList = new List<Buff>();
    
    private GameEventMgr _eventMgr;

    protected GameEventMgr EventMgr
    {
        get
        {
            if (_eventMgr == null)
            {
                _eventMgr = MemoryPool.Acquire<GameEventMgr>();
            }

            return _eventMgr;
        }
    }
    //添加事件，保存在事件列表中，角色销毁时移除
    protected void AddEvent(string eventName, Action action)
    {
        EventMgr.AddEvent(RuntimeId.ToRuntimeId(eventName), action);
    }
    
    //添加Buff
    public void AddBuff(Buff buff)
    {
        BuffList.Add(buff);
        //有重复的执行重复添加
        if (BuffList.Contains(buff))
        {
            buff.OnRepeatAdd();
        }
        else
        {
            buff.OnAdd();
        }
        Log.Info("AddBuff",buff.ToString());
    }
    //移除Buff
    public void RemoveBuff(Buff buff)
    {
        buff.OnRemove();
        BuffList.Remove(buff);
        Log.Info("RemoveBuff",buff.ToString());
    }
    
    
    //处理buff生命周期
    private void OnRoundEnd()
    {
        for (int i = 0; i < BuffList.Count; i++)
        {
            BuffList[i].LifeTime--;
            if (BuffList[i].LifeTime <= 0)
            {
                RemoveBuff(BuffList[i]);
            }
        }
    }
    
    //初始化
    public virtual void Init()
    {
        Log.Info("Entity Init");
        AddEvent(EventEnum.OnRoundEnd, OnRoundEnd);
    }
    
    
    //销毁
    public virtual void Destroy()
    {
        Log.Info("Entity Destroy");
        if (_eventMgr != null)
        {
            MemoryPool.Release(_eventMgr);
        }
        
    }
    //更新
    public virtual void Update()
    {
        
    }

    public void Clear()
    {
        BuffList.Clear();
    }
}