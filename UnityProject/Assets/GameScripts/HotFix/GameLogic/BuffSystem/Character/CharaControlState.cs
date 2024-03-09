
// 角色控制状态 用于控制角色的行为
public class CharaControlState
{
    //是否能移动
    public bool canMove;
    
    //是否能攻击
    public bool canAttack;
    
    //是否能释放技能
    public bool canUseSkill;
    
    //是否能被控制
    public bool canBeControl;
    
    //是否能被击飞
    public bool canBeHitFly;
    
    //是否能被减速
    public bool canBeSlow;
}