
using System;
using System.Collections.Generic;
using System.Linq;
using FEngine;
using UnityEngine;

public class Snake:MonoBehaviour
{
    
    //蛇身
    public List<SnakeSegment> Segments=new List<SnakeSegment>();
    //蛇移动速度
    public float Speed = 1;

    //蛇尾偏移
    public float TailOffset = 3f;
    
    public Vector2 Direction;
    
    public Vector3 MousePos;
    
    public List<Vector3> Positions=new List<Vector3>();
    public List<float> Directions=new List<float>();
    
    private void Update()
    {
        //获取鼠标位置,舌头朝向鼠标位置
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MousePos = new Vector3(mousePos.x, mousePos.y, 0);
        Direction = (mousePos - transform.position).normalized;
        
        var width = Main.Instance.width;
        var height = Main.Instance.height;
        //检测是否越界,如果越界游戏结束
        if (transform.position.x < -width / 2 || transform.position.x > width / 2 || transform.position.y < -height / 2 || transform.position.y > height / 2)
        {
            Debug.Log("Game Over");
            Destroy(gameObject);
        }
    }
    
    private void FixedUpdate()
    {
        //移动蛇
        transform.LookAt2DY(MousePos);
        
        Directions.Add(transform.eulerAngles.z);
        
        Direction = (MousePos - transform.position).normalized;
        
        var newPosition=transform.position+new Vector3(Direction.x,Direction.y,0)*Speed*Time.fixedDeltaTime;
        transform.position = newPosition;
        Positions.Add(newPosition);
        
        //更新蛇身位置
        if (Segments.Count > 0)
        {
            UpdateSegments();
        }
       
    }

    private void UpdateSegments()
    {
        
        for (int i = 0; i < Segments.Count; i++)
        {
            Segments[i].transform.position = LastPosition(i*10);
            Segments[i].transform.eulerAngles = new Vector3(0, 0, LastDirection(i*10));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //如果碰撞到食物，则调用Eat方法
        if (other.CompareTag("Food"))
        {
            Eat();
            Destroy(other.gameObject);
        }
    }
    

    //碰撞到食物时调用
    public void Eat()
    {
        //生成一个新的蛇身，依据蛇尾位置，方向，生成新的蛇身
        var tail = Instantiate(Main.Instance.SnakeSegmentPrefab,transform).GetComponent<SnakeSegment>();
        tail.transform.ResetLocalTransform();
        
        tail.transform.position = LastPosition(10*(Segments.Count+1));
        tail.transform.eulerAngles = new Vector3(0, 0, LastDirection(Segments.Count));
        //将新的蛇身添加到蛇身列表中
        Segments.Add(tail);
    }

    private float LastDirection(int index)
    {
        if (Directions.Count > index)
        {
            return Directions[Directions.Count-1 - index];
        }
        return transform.eulerAngles.z;
    }

    private Vector3 LastPosition(int index)
    {
        if (Positions.Count > index)
        {
            return Positions[Positions.Count-1 - index];
        }
        return transform.position;
    }
}

