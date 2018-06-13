namespace Anueves1.SaveSystem
{
    public abstract class Savable
    {
        public int Id = 1;

        public abstract void Load(object data);
    }
}