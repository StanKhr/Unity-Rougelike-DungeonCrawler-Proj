using UnityEngine;

namespace UI.Interfaces
{
    public interface IScanDescription
    {
        #region Properties

        string Name { get; }
        Color Color { get; }
        
        #endregion
    }
}