using Unity.Entities;
using UnityEngine;

namespace Anueves1.SaveSystem
{
    public class SaveManagerSystem : ComponentSystem
    {
        private struct Filter
        {
            public SaveManagerComponent SaveManager;
        }

        protected override void OnUpdate()
        {
            //Go trough the entities.
            foreach (var entity in GetEntities<Filter>())
            {
                switch (entity.SaveManager.Action)
                {
                    //Skip this entity if we don't need to execute anything.
                    case 0:
                        continue;
                    //Save or load based on need.
                    case 1:
                        SaveAll(entity.SaveManager);
                        break;
                    default:
                        LoadAll(entity.SaveManager);
                        break;
                }

                //Don't execute again next frame.
                entity.SaveManager.Action = 0;
            }
        }

        private static void SaveAll(SaveManagerComponent component)
        {
            //Go trough all the savers and save each of them.
            foreach (var s in component.Savables)
            {
                //Save the data from the object.
                JSONSolver.Write(s.Id.ToString(), s);
            }
            
            Debug.Log("Finished saving.");
        }

        private static void LoadAll(SaveManagerComponent component)
        {
            //Go trough all the savers and load each of them.
            foreach (var s in component.Savables)
            {
                //Load the data.
                var objectData = JSONSolver.Read(s.Id.ToString(), s);
                
                //Load the object data.
                s.Load(objectData);
            }
            
            Debug.Log("Finished Loading");
        }
    }
}