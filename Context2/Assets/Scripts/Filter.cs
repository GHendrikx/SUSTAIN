using System.Collections.Generic;

namespace Context
{
    public class Filter
    {
        private List<SDGType> filter = new List<SDGType>();

        public void StartFiltering()
        {
            for (int i = 1; i < 18; i++)
                filter.Add((SDGType)i);
        }

        /// <summary>
        /// Executed from UNITY_EDITOR
        /// </summary>
        public void Toggeling(SDGType sdgType)
        {
            if (!filter.Contains(sdgType))
                filter.Add(sdgType);
            else
                filter.Remove(sdgType);
        }
    }
}