namespace Acme.GenericBusiness.MonsterSpawner
{
    public class Monster
    {
        public string Name { get; set; }
        public Weapon Weapon { get; set; }
        public Alignment Alignment { get; set; }
        
        public int Level { get; set; }
        public int Hitpoints { get; set; }
        
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Wisdom { get; set; }
    }
}