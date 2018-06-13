using Unity.Entities;

namespace Anueves1.SaveSystem
{
    public class DataTypesSystem : ComponentSystem
    {
        private struct Filter
        {
            public DataTypesComponent Data;
        }

        protected override void OnStartRunning()
        {
            //Go trough the entities.
            foreach (var entity in GetEntities<Filter>())
            {
                //Add this object to the savables list.
                SaveManagerComponent.Instance.Savables.Add(entity.Data.UsableData);
            }
        }

        protected override void OnUpdate()
        {
            //Go trough the entities.
            foreach (var entity in GetEntities<Filter>())
            {
                //Get the int text.
                var intText = "Int " + entity.Data.UsableData.Int.ToString();
                
                //Get the float text.
                var floatText = "Float " + entity.Data.UsableData.Float.ToString();
                
                //Get the vector text.
                var vectorText = "Vector3 " + entity.Data.UsableData.Vector.ToString();
                
                //Set the text.
                entity.Data.Text.text = intText + " " + floatText + " " + vectorText;
            }
        }
    }
}