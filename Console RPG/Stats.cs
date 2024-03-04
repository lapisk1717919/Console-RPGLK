namespace Console_RPG
{
    struct Stats
    {
        public float strength; //physAtk
        public float defense; //physDef
        public float intelligence; //magicAtk
        public float fortitude; //magicDef

        public Stats(float strength, float defense, float intelligence, float fortitude)
        {
            this.strength = strength;
            this.defense = defense;
            this.intelligence = intelligence;
            this.fortitude = fortitude;
        }
    }
}
