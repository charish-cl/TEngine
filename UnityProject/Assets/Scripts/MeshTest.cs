
using System;
using UnityEngine;

public class MeshTest:MonoBehaviour
{
    public Mesh Mesh;
    public Material Material;
    private void Start()
    {
      matrices=new Matrix4x4[1000];
    }

    Matrix4x4[] matrices;
    private void Update()
    {
       //绘制1000Mesh每个位置都不一样
       
       for (int i = 0; i < 1000; i++)
       { 
           //随机生成位置
              var x = UnityEngine.Random.Range(-100, 100);
              var y = UnityEngine.Random.Range(-100, 100);
              matrices[i]=Matrix4x4.TRS(new Vector3(x,y,0), Quaternion.identity, Vector3.one);
       }
       
       Graphics.DrawMeshInstanced(Mesh, 0, Material, matrices);

    }
}