using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Models
{
    [CreateAssetMenu(fileName = "PipeMangerModel", menuName = "ScriptableObjects/PipeManagerModel", order = 1)]
    public class PipeManagerModel : ScriptableObject
    {
        public float DistanceBetweenObjectsX;
        public float HeightObjectsY;
        public GameObject[] Prefabs;
        public int maxPipesInScene;
    } 
}
