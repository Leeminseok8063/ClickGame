using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    public interface ICreature
    {
        public void SetData(CreatureData data);
    }

    public interface IDamagable
    {
        public void TakeDamage(float damage);
    }

    public interface ISpawnable
    {
        public void IsSpawned();
    }
}
