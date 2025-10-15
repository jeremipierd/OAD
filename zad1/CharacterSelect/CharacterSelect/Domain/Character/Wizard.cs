using CharacterSelect.Application;
using CharacterSelect.Domain.Enum;

namespace CharacterSelect.Domain.Character;

public sealed class Wizard : Entity.Character
{
    public Wizard(string name) : base(name, CharacterClass.Wizard)
    {
        Health = 50;
        Strength = 1;
        Intelligence = 20;
        Agility = 10;
        Fun = 10;
        Sadness = 20;
    }
}