
using System.Collections.Generic;
using TEngine;
/// <summary>
/// 战斗系统，负责战斗逻辑，包括技能，buff，战斗单位的行为等
/// </summary>
public class BattleSystem:BaseLogicSys<BattleSystem>
{
    //为实体生成唯一ID方法
    private int _entityId = 0;
    int GenerateEntityId()
    {
        return _entityId++;
    }
    public List<Entity> entityList = new List<Entity>();
    //创建实体
    public Entity CreateEntity()
    {
        Entity entity = new Entity
        {
            ID = GenerateEntityId()
        };
        entityList.Add(entity);
        return entity;
    }
  

    public override void OnStart()
    {
        GameEvent.Send(EventEnum.OnRoundEnd);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}
