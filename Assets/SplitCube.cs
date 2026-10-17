using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class SplitCube : MonoBehaviour
{
    void Awake()
    {
        MeshFilter mf = GetComponent<MeshFilter>();
        if (mf == null || mf.sharedMesh == null) return;

        // Instantiate a new instance of the mesh so original assets aren't modified
        Mesh mesh = Instantiate(mf.sharedMesh);
        
        // A standard Unity primitive cube has 24 vertices and 36 indices (6 sub-triangles per face)
        if (mesh.triangles.Length == 36)
        {
            mesh.subMeshCount = 6;
            int[] origTriangles = mesh.triangles;

            for (int i = 0; i < 6; i++)
            {
                int[] faceTriangles = new int[6];
                System.Array.Copy(origTriangles, i * 6, faceTriangles, 0, 6);
                mesh.SetTriangles(faceTriangles, i);
            }

            mf.mesh = mesh;
        }
    }
}