using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Models
{
    [CreateAssetMenu(fileName = "PlayerModel", menuName = "ScriptableObjects/PlayerModel", order = 1)]
    public class PlayerModel : ScriptableObject
    {
        public float ForceMultiplayerUp;
        public float ForceMultiplayerTowards;
        /// <summary>
        /// This Var declare how big is bomb area
        /// </summary>
        public float SizeOfArea;
        public float doubleClickTime = 1f;
    }
}