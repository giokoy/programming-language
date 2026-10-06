using System;

abstract class Character
{
    private readonly string _characterType;

    protected Character(string characterType)
    {
        _characterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        return false;
    }

    public override string ToString()
    {
        return $"Character is a {_characterType}";
    }
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        return target.Vulnerable() ? 10 : 6;
    }
}

class Wizard : Character
{
    private bool _hasPreparedSpell = false;

    public Wizard() : base("Wizard")
    {
    }

    public void PrepareSpell()
    {
        _hasPreparedSpell = true;
    }

    public override bool Vulnerable()
    {
        return !_hasPreparedSpell;
    }

    public override int DamagePoints(Character target)
    {
        return _hasPreparedSpell ? 12 : 3;
    }
}