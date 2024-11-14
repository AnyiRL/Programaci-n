using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "HearAction (A)", menuName = "ScriptableObject/Action/HearAction")]

//public class SeeAction : Monovehaviour
//{
//    public float distance = 10;
//    public float angle = 30;
//    public float height = 1.0f;
//    public Color meshColor = Color.red;
    
//    Mesh mesh;
//    public override bool Check(GameObject owner)
//    {
//        throw new System.NotImplementedException();
//    }

//    public override void DrawGizmos(GameObject owner)
//    {
//        if (mesh)
//        {
//            DrawGizmos().color = meshColor;
//            DrawGizmos().DrawMesh(mesh, transform.position, transform.rotation);

//        }
//    }

//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }

//    Mesh CreateWedgeMesh()
//    {
//        Mesh mesh = new Mesh();
//        int numTriangles = 8;
//        int numVertices = numVertices * 3;

//        Vector3[] vertices = new Vector3[numVertices];
//        int[] triangles = new int[numVertices];

//        Vector3 bottomCenter = Vector.zero;
//        Vector3 bottomRight = Quaternion.Euler(0, -angle,0) * Vector3.forward * distance;
//        Vector3 bottomLeft = Quaternion.Euler(0, angle,0) * Vector3.forward * distance;

//        Vecto3 topCenter = bottomCenter + Vector.up * height;
//        Vecto3 topRight = bottomRight + Vector.up * height;
//        Vecto3 topLeft = bottomLeft + Vector.up * height;

//        int vert = 0;

//        //left side
//        vertices[vert++] = bottomCenter;
//        vertices[vert++] = bottomLeft;
//        vertices[vert++] = topLeft;

//        vertices[vert++] = topLeft;
//        vertices[vert++] = topCenter;
//        vertices[vert++] = bottomCenter;
//        //right side
//        vertices[vert++] = bottomCenter;
//        vertices[vert++] = topCenter;
//        vertices[vert++] = topRight;

//        vertices[vert++] = topRight;
//        vertices[vert++] = bottomRight;
//        vertices[vert++] = bottomCenter;

//        //far side
//        vertices[vert++] = bottomLeft;
//        vertices[vert++] = bottomRight;
//        vertices[vert++] = topRight;

//        vertices[vert++] = topRight;
//        vertices[vert++] = topLeft;
//        vertices[vert++] = bottomLeft;

//        //top
//        vertices[vert++] = topCenter;
//        vertices[vert++] = topLeft;
//        vertices[vert++] = topRight;
        
//        //bottom
//        vertices[vert++] = bottomCenter;
//        vertices[vert++] = bottomRight;
//        vertices[vert++] = bottomLeft;

//        for (int i = 0; i < numVertices; i++)
//        {
//            triangles[i] = i;
//        }

//        mesh.vertices = vertices;   
//        mesh.triangles = triangles;
//        mesh.RecalculateNormals();

//        return mesh;

//    }

//    private void OnValidate()
//    {
//        mesh = CreateWedgeMesh();
//    }
//}
