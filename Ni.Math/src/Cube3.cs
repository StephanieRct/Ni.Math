using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using Unity.Mathematics;
using UnityEditor;

namespace Ni.Mathematics
{
    [InitializeOnLoad]
    public static class Cube3
    {
        public static readonly float3 IdentityMin = float3.zero;
        public static readonly float3 IdentityMax = new float3(1);
        public static readonly float3 OriginMin = new float3(-0.5f);
        public static readonly float3 OriginMax = new float3(0.5f);


        /// <summary>
        /// =======================  
        /// | Vertices            |
        /// =======================
        /// |                     |
        /// |      1----------4   |
        /// |     /|         /|   |
        /// |    / |        / |   |
        /// |   6----------3  |   |
        /// |   |  |       |  |   |
        /// |   |  7-------|--2   |
        /// |   | /        | /    |
        /// |   |/         |/     |
        /// |   0----------5      |
        /// |                     |
        /// ===========================================================================================================================================================
        /// |                                      Corners                                                                                                                                  |
        /// =================================================================================================================================================================================   
        /// |                     |                     |                     |                     |                     |                     |                     |                     |
        /// |                     |      1----------4   |                4    |                 4   |      1----------4   |                     |      1              |      1              |
        /// |                     |     /|              |                |    |                /    |                /|   |                     |     /               |      |              |
        /// |                     |    / |              |                |    |               /     |               / |   |                     |    /                |      |              |
        /// |   6                 |   6  |              |                |    |    ----------3      |              3  |   |              3      |   6----------3      |      |              |
        /// |   |                 |      |              |                |    |              |      |                 |   |              |      |   |                 |      |              |
        /// |   |  7              |      7              |     7----------2    |              |      |                 2   |              |  2   |   |                 |      7----------2   |
        /// |   | /               |                     |               /     |              |      |                     |              | /    |   |                 |     /               |
        /// |   |/                |                     |              /      |              |      |                     |              |/     |   |                 |    /                |
        /// |   0----------5      |                     |             5       |              5      |                     |   0----------5      |   0                 |   0                 |
        /// |                     |                     |                     |                     |                     |                     |                     |                     |
        /// =================================================================================================================================================================================
        /// |                     |                     |                     |                     |                     |                     |                     |                     |
        /// |      1          4   |      1----------4   |     1          4    |      1          4   |      1----------4   |      1          4   |      1          4   |      1          4   |
        /// |                     |     /|              |                |    |                /    |                /|   |                     |     /               |      |              |
        /// |                     |    / |              |                |    |               /     |               / |   |                     |    /                |      |              |
        /// |   6          3      |   6  |       3      |   6         3  |    |   6----------3      |   6          3  |   |   6          3      |   6----------3      |   6  |       3      |
        /// |   |                 |      |              |                |    |              |      |                 |   |              |      |   |                 |      |              |
        /// |   |  7          2   |      7          2   |     7----------2    |      7       |  2   |      7          2   |      7       |  2   |   |  7          2   |      7----------2   |
        /// |   | /               |                     |               /     |              |      |                     |              | /    |   |                 |     /               |
        /// |   |/                |                     |              /      |              |      |                     |              |/     |   |                 |    /                |
        /// |   0----------5      |   0          5      |   0         5       |   0          5      |   0          5      |   0----------5      |   0          5      |   0          5      |
        /// |                     |                     |                     |                     |                     |                     |                     |                     |
        /// =================================================================================================================================================================================                 
        /// 
        /// </summary>
        /// 
        public enum Vertex
        {
            Vertex000 = 0, // Vertex 0
            Vertex100 = 1, // Vertex 1
            Vertex010 = 2, // Vertex 2
            Vertex110 = 3, // Vertex 3
            Vertex001 = 4, // Vertex 4
            Vertex101 = 5, // Vertex 5
            Vertex011 = 6, // Vertex 6
            Vertex111 = 7, // Vertex 7
        }

        public static IEnumerable<float3> IdentityVertices
        {
            get
            {
                yield return new float3(0, 0, 0);
                yield return new float3(0, 1, 1);
                yield return new float3(1, 0, 1);
                yield return new float3(1, 1, 0);
                yield return new float3(1, 1, 1);
                yield return new float3(1, 0, 0);
                yield return new float3(0, 1, 0);
                yield return new float3(0, 0, 1);
            }
        }

        /// <summary>
        /// ===================================================================    
        /// | Shape               | Vertices            |  Edges              |
        /// ===================================================================
        /// |                     |                     |                     |
        /// |      *----------*   |      1----------4   |      *----3-----*   |
        /// |     /|         /|   |     /|         /|   |     /|         /|   |
        /// |    / |        / |   |    / |        / |   |    5 4       10 |   |
        /// |   *----------*  |   |   6----------3  |   |   *-----9----*  7   |
        /// |   |  |       |  |   |   |  |       |  |   |   |  |       |  |   |
        /// |   |  *-------|--*   |   |  7-------|--2   |   1  *----6--|--*   |
        /// |   | /        | /    |   | /        | /    |   | 2       11 8    |
        /// |   |/         |/     |   |/         |/     |   |/         |/     |
        /// |   *----------*      |   0----------5      |   *----0-----*      |
        /// |                     |                     |                     |
        /// =====================================================================================================================================
        /// | Edge sequence                                                                                                                     |
        /// =====================================================================================================================================
        /// |0/                   |1/                   |2/                   |3/                   |4/                   |5/                   |
        /// |/     1          4   |/     1          4   |/     1          4   |/     1--------->4   |/     1          4   |/     1          4   |
        /// |                     |                     |                     |                     |      |              |     /               |
        /// |                     |                     |                     |                     |      |              |   |/                |
        /// |   6          3      |   6          3      |   6          3      |   6          3      |   6  |       3      |   6          3      |
        /// |                     |  /|                 |                     |                     |      |/             |                     |
        /// |      7          2   |   |  7          2   |      7          2   |      7          2   |      7          2   |      7          2   |
        /// |                     |   |                 |     /|              |                     |                     |                     |
        /// |                     |   |                 |    /                |                     |                     |                     |
        /// |   0--------->5      |   0          5      |   0          5      |   0          5      |   0          5      |   0          5      |
        /// |                     |                     |                     |                     |                     |                     |
        /// =====================================================================================================================================
        /// |6/                   |7/                   |8/                   |9/                   |10/                  |11/                  |
        /// |/     1          4   |/     1          4   |/     1          4   |/     1          4   |/     1          4   |/     1          4   |
        /// |                     |                 |\  |                     |                     |                     |                /|   |
        /// |                     |                 |   |                     |                     |                     |               /     |
        /// |   6          3      |   6          3  |   |   6          3      |   6<---------3      |   6          3      |   6          3      |
        /// |                     |                 |   |                     |                     |              |      |                     |
        /// |      7<--------2    |      7          2   |      7          2   |      7          2   |      7       |  2   |      7          2   |
        /// |                     |                     |                /    |                     |              |      |                     |
        /// |                     |                     |              |/     |                     |              |/     |                     |
        /// |   0          5      |   0          5      |   0          5      |   0          5      |   0          5      |   0          5      |
        /// |                     |                     |                     |                     |                     |                     |
        /// =====================================================================================================================================
        /// </summary>
        public enum Edge
        {
            Edge000100 = 0,  // Edge  0, Vertices: (0, 5)
            Edge000010 = 1,  // Edge  1, Vertices: (0, 6)
            Edge000001 = 2,  // Edge  2, Vertices: (0, 7)
            Edge011111 = 3,  // Edge  3, Vertices: (1, 4)
            Edge011001 = 4,  // Edge  4, Vertices: (1, 7)
            Edge011010 = 5,  // Edge  5, Vertices: (1, 6)
            Edge101001 = 6,  // Edge  6, Vertices: (2, 7)
            Edge101111 = 7,  // Edge  7, Vertices: (2, 4)
            Edge101100 = 8,  // Edge  8, Vertices: (2, 5)
            Edge110010 = 9,  // Edge  9, Vertices: (3, 6)
            Edge110100 = 10, // Edge 10, Vertices: (3, 5)
            Edge110111 = 11, // Edge 11, Vertices: (3, 4)
        }


        public static IEnumerable<int2> IdentityEdgesIndices
        {
            get
            {
                yield return new int2(0, 5);
                yield return new int2(0, 6);
                yield return new int2(0, 7);
                yield return new int2(1, 4);
                yield return new int2(1, 7);
                yield return new int2(1, 6);
                yield return new int2(2, 7);
                yield return new int2(2, 4);
                yield return new int2(2, 5);
                yield return new int2(3, 6);
                yield return new int2(3, 5);
                yield return new int2(3, 4);
            }
        }
        public static IEnumerable<LineSegment3> IdentityEdges
        {
            get
            {
                for (int i = 0; i < IdentityEdgesIndicesArray.Length; i++)
                    yield return new LineSegment3(IdentityVerticesArray[IdentityEdgesIndicesArray[i].x], IdentityVerticesArray[IdentityEdgesIndicesArray[i].y]);
            }
        }



        public static NativeArray<float3> IdentityVerticesArray;
        public static NativeArray<int2> IdentityEdgesIndicesArray;
        public static NativeArray<LineSegment3> IdentityEdgesArray;
        static Cube3()
        {
            IdentityVerticesArray = new NativeArray<float3>(IdentityVertices.ToArray(), Allocator.Persistent);
            IdentityEdgesIndicesArray = new NativeArray<int2>(IdentityEdgesIndices.ToArray(), Allocator.Persistent);
            IdentityEdgesArray = new NativeArray<LineSegment3>(IdentityEdges.ToArray(), Allocator.Persistent);
#if UNITY_EDITOR
            UnityEditor.AssemblyReloadEvents.beforeAssemblyReload += Dispose;
#endif
        }
        static void Dispose()
        {
            IdentityVerticesArray.Dispose();
            IdentityEdgesIndicesArray.Dispose();
            IdentityEdgesArray.Dispose();
#if UNITY_EDITOR
            UnityEditor.AssemblyReloadEvents.beforeAssemblyReload -= Dispose;
#endif
        }
    }
}