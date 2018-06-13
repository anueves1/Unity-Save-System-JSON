using UnityEngine;
using System.Collections.Generic;

namespace Anueves1.SaveSystem
{
    public class SaveManagerComponent : MonoBehaviour
    {
        public static SaveManagerComponent Instance
        {
            get { return FindObjectOfType<SaveManagerComponent>(); }
        }
        
        [HideInInspector] 
        public List<Savable> Savables = new List<Savable>();
        
        [HideInInspector] 
        public int Action;

        public void Save() { Action = 1; }

        public void Load() { Action = 2; }
    }
}