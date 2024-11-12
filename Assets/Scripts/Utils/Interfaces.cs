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
        /// <summary>
        /// 데이터를 설정합니다.
        /// </summary>
        /// <param name="data"></param>
        public void SetData(CreatureData data);
    }

    public interface IDamagable
    {
        public void TakeDamage(float damage);
    }

    public interface ISpawnable
    {
        /// <summary>
        /// 대상이 스폰될때의 설정과 시작위치와 최종 이동 위치를 설정합니다.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="dest"></param>
        public void IsSpawned(Vector3 start, Vector3 dest);
    }
}
