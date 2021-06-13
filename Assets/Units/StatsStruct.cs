using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum UnitType { Foot, Mount, Fly }

public enum StatNames { HP, Strength, Defense, Magic, Resistance,Speed, Luck, Constitution }

[Serializable]
public struct StatsStruct
{
    public int HP;
    public int Strength;
    public int Defense;
    public int Magic;
    public int Resistance;
    public int Speed;
    public int Luck;
    public int Constitution;

    public int returnStat(StatNames name)
    {
        switch (name)
        {
            case StatNames.HP:
                return HP;
            case StatNames.Strength:
                return Strength;
            case StatNames.Defense:
                return Defense;
            case StatNames.Magic:
                return Magic;
            case StatNames.Resistance:
                return Resistance;
            case StatNames.Speed:
                return Speed;
            case StatNames.Luck:
                return Luck;
            case StatNames.Constitution:
                return Constitution;
            default:
                return -1;
        }

    }


}

