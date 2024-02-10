using System;
using System.Reflection;
using UnityEngine;

public abstract class EnemyFactory
{
    public abstract GameObject CreateSmile(string nameSmile);

    public abstract GameObject CreateSimple();

    public abstract GameObject CreateShield();

    public abstract GameObject CreatePowerFly();
}
