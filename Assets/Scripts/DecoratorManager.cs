using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DecoratorManager : MonoBehaviour
{
    public List<Decoration> DecorationList = new();
    public List<GameObject> InstantiatedDecorationList = new();
    public Vector3 MapSize;
    [SerializeField] private Transform _decorationParent;

#if UNITY_EDITOR
    [Button]
    public void Decorate()
    {
        EraseDecorations();

        for (int i = 0; i < DecorationList.Count; i++)
        {
            for (int j = 0; j < DecorationList[i].Frequency; j++)
            {
                GameObject decoration = (GameObject)PrefabUtility.InstantiatePrefab(DecorationList[i].DecorationPrefab, _decorationParent);
                decoration.transform.position = new Vector3(Random.Range(-MapSize.x / 2, MapSize.x / 2) + transform.position.x, 
                    Random.Range(-MapSize.y / 2, MapSize.y / 2) + transform.position.y, 
                    Random.Range(-MapSize.z / 2, MapSize.z / 2) + transform.position.z); 
                InstantiatedDecorationList.Add(decoration);
            }
        }
    }

    [Button]
    public void EraseDecorations()
    {
        for (int i = 0; i < InstantiatedDecorationList.Count; i++)
        {
            DestroyImmediate(InstantiatedDecorationList[i].gameObject);
        }

        InstantiatedDecorationList.Clear();
    }

#endif

    [System.Serializable]
    public class Decoration
    {
        public GameObject DecorationPrefab;
        public float Frequency;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, MapSize);
    }
}
