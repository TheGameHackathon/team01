namespace thegame
{
    public class GameObject
    {
        public GameObject(int id)
        {
            Id = id;
        }
        public string Type { get; set; }
        public int Id { get; }
    }
}