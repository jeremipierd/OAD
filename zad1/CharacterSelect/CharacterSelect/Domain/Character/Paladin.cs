using CharacterSelect.Application;
using CharacterSelect.Domain.Enum;

namespace CharacterSelect.Domain.Character;

public sealed class Paladin : Entity.Character
{
    public Paladin(string name) : base(name, CharacterClass.Paladin)
    {
        Health = 200;
        Strength = 10;
        Intelligence = 10;
        Agility = 1;
        Fun = 10;
        Sadness = 20;
    }
}