
using TEngine;
using UnityEngine;

/// <summary>
/// 这个主要用来生成地形，怪物，碰撞检测的
/// </summary>
public class MapSystem:BaseLogicSys<MapSystem>
{
    public Vector2Int gridSize = new Vector2Int(10,10);
    
    //寻路
    //AStarPathfinding pathfinding;

    //private Grid<AstarNode> grid => pathfinding.grid;
    public override void OnStart()
    {
      //  pathfinding = new AStarPathfinding(gridSize.x, gridSize.y);
    }
    /// <summary>
    /// 左键添加障碍物,右键寻路
    /// </summary>
    public override void OnUpdate()
    {
        // if (Input.GetMouseButtonDown(0))
        // {
        //     var cell = pathfinding.grid.GetMouseTargetCell();
        //     cell.isWalkable = false;
        //     cell.SetColor(Color.black);
        // }
        // if (Input.GetMouseButtonDown(1))
        // {
        //     var cell = pathfinding.grid.GetMouseTargetCell();
        //     var result = pathfinding.FindPath(Vector2.zero, pathfinding.grid.GetCellPosition(cell.coordinate));
        //         
        //     for (var i = 0; i < result.Count-1; i++)
        //     {
        //         Debug.DrawLine(result[i],result[i+1],Color.green,1);
        //     }
        // }
    }

    //通过鼠标获取落在当前格子的节点
    // public AstarNode GetMouseTargetCell()
    // {
    //     return grid.GetMouseTargetCell();
    // }
    //
    
    public override void OnDestroy()
    {
        
    }
}
