using System;
using System.IO;
using UnityEngine;

namespace Anueves1.SaveSystem
{
    public static class JSONSolver
    {
        public static void Write(string name, object o)
        {
            //Get the path where this file will be located.
            var path = Application.persistentDataPath + "/" + name + ".json";

            //Get the contents from the file.
            var contents = JsonUtility.ToJson(o, true);

            //Write the contents.
            File.WriteAllText(path, contents);
        }

        public static void Delete(string name)
        {
            //Get the path where this file will be located.
            var path = Application.persistentDataPath + "/" + name + ".json";

            //If there's no file at said path, don't do anything.
            if (File.Exists(path) == false)
                return;

            //Delete the file.
            File.Delete(path);
        }

        public static object Read(string name, object o)
        {
            //Get the path where this file will be located.
            var path = Application.persistentDataPath + "/" + name + ".json";

            //If there's no file at said path, don't do anything.
            if (File.Exists(path) == false)
                return o;

            //Read all the contents.
            var contents = File.ReadAllText(path);          

            //Read the data from the json file.
            return JsonUtility.FromJson(contents, o.GetType());
        }

        public static void Overwrite(string name, object obj)
        {
            //Get the path where this file will be located.
            var path = Application.persistentDataPath + "/" + name + ".json";

            //If there's no file at said path, don't do anything.
            if (File.Exists(path) == false)
                return;

            //Read all the contents.
            var contents = File.ReadAllText(path);

			//Overwrite the object.
            JsonUtility.FromJsonOverwrite(contents, obj);
        }
    }
}