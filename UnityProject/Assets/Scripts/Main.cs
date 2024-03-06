using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using FEngine;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

public class Main : MonoSingleton<Main>
{
    
    public int width = 100;
    public int height = 100;
    
    
    [LabelText("食物生成间隔")]
    public float interval = 0.1f;
    
    [LabelText("食物预制体")]
    public GameObject FoodPrefab; 
    [LabelText("蛇预制体")]
    public GameObject SnakePrefab;
    [LabelText("蛇身预制体")]
    public GameObject SnakeSegmentPrefab;
    
    
    Snake Snake;
    
    public Mesh Mesh;
    public Material Material;
    void Start()
    {
         //生成蛇
         Snake = Instantiate(SnakePrefab, Vector3.zero, Quaternion.identity).GetComponent<Snake>();
            
         //用UniTask每隔interval秒生成一个食物
         GenerateFood();
         
    }

   

    private async void GenerateFood()
    {
        while (true)
        {
            await UniTask.Delay((int)(interval * 1000));
            var x = Random.Range(-width / 2, width / 2);
            var y = Random.Range(-height / 2, height / 2);
            Instantiate(FoodPrefab, new Vector3(x, y, 0), Quaternion.identity);
            
        }
    }

    
    private void OnDrawGizmos()
    {
        //绘制地图边界
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(-width / 2, -height / 2, 0), new Vector3(width / 2, -height / 2, 0));
        Gizmos.DrawLine(new Vector3(-width / 2, height / 2, 0), new Vector3(width / 2, height / 2, 0));
        Gizmos.DrawLine(new Vector3(-width / 2, -height / 2, 0), new Vector3(-width / 2, height / 2, 0));
        Gizmos.DrawLine(new Vector3(width / 2, -height / 2, 0), new Vector3(width / 2, height / 2, 0));
    }
}
