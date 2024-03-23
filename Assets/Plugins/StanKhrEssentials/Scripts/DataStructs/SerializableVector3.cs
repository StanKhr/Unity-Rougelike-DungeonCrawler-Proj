using System;
using UnityEngine;

namespace Plugins.StanKhrEssentials.Scripts.DataStructs
{
    [Serializable]
    public struct SerializableVector3
    {
        #region Constants

        private const float CompareTolerance = 0f;

        #endregion
        
        #region Constructors

        public SerializableVector3(Vector3 vector3)
        {
            X = vector3.x;
            Y = vector3.y;
            Z = vector3.z;
        }

        public SerializableVector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        #endregion
        
        #region Properties

        [field: SerializeField] public float X { get; set; }
        [field: SerializeField] public float Y { get; set; }
        [field: SerializeField] public float Z { get; set; }

        #endregion

        #region Methods

        public Vector3 GetVector3()
        {
            return new Vector3(X, Y, Z);
        }

        public bool Equals(Vector3 vector3)
        {
            return Math.Abs(X - vector3.x) < CompareTolerance
                   && Math.Abs(Y - vector3.y) < CompareTolerance
                   && Math.Abs(Z - vector3.z) < CompareTolerance;
        }

        public bool Equals(SerializableVector3 serializableVector3)
        {
            return Equals(serializableVector3.GetVector3());
        }

        #endregion
    }
}