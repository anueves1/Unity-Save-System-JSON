using UnityEngine;
using UnityEngine.UI;

namespace Anueves1.SaveSystem
{
    public class DataTypesComponent : MonoBehaviour
    {
        public Text Text;
        
        public DataTypesData UsableData;   
    }
    
    [System.Serializable]
    public class DataTypesData : Savable
    {      
        public int Int = 2;

        public float Float = 2f;
        
        public Vector3 Vector = new Vector3(2, 2, 2);
            
        public override void Load(object data)
        {
            //Convert the data to the needed type.
            var dTypesData = (DataTypesData) data;

            //Get the data.
            
            Int = dTypesData.Int;

            Float = dTypesData.Float;

            Vector = dTypesData.Vector;
        }
    } 
}