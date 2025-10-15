using CharacterSelect.Application;
using CharacterSelect.Domain.Enum;

namespace CharacterSelect.Domain.Character;

public sealed class Knight : Entity.Character
{
    public Knight(string name) : base(name, CharacterClass.Knight)
    {
        Health = 150;
        Strength = 10;
        Intelligence = 5;
        Agility = 5;
        Fun = 10;
        Sadness = 20;
    }
}