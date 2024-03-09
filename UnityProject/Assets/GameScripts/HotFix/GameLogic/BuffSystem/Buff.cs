
using Sirenix.OdinInspector;
using TEngine;

public class Buff
{
    //生命周期
    [LabelText("回合数")]
    public int LifeTime;
    
    
    //添加时
    public virtual void OnAdd()
    {
       
    }
    //重复添加
    public virtual void OnRepeatAdd()
    {
        
    }

    //移除时
    public virtual void OnRemove()
    {
        
    }

    //根据类型判断是否相等
    public override bool Equals(object obj)
    {
        //根据类型
        if (obj.GetType() == GetType())
        {
            return true;
        }
        return false;
    }
}
