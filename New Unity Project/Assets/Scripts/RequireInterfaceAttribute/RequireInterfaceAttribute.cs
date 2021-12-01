using UnityEngine;

namespace RequireInterfaceAttribute
{
    
    
    public class RequireInterfaceAttribute : PropertyAttribute
    {
        // Interface type.
        public System.Type RequiredType { get; private set; }

        /// <summary>
        /// Requiring implementation of the <see cref="T:Utilities.RequireInterfaceAttribute"/> interface.
        /// </summary>
        /// <param name="type">Interface type.</param>
        public RequireInterfaceAttribute(System.Type type)
        {
            this.RequiredType = type;
        }
    }
}
