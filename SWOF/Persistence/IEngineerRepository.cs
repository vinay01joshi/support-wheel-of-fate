using SWOF.Core.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWOF.Persistence
{
    public interface IEngineerRepository
    {
        /// <summary>
        /// Reads all the engineers from the repository
        /// </summary>
        /// <returns>List of engineers</returns>
        IEnumerable<EngineerModel> ReadAll();

        /// <summary>
        /// Adds a new engineer to the repository
        /// </summary>
        /// <param name="engineer">The engineer to add</param>
        void Add(EngineerModel engineer);

        /// <summary>
        /// Removes a specific engineer from the repository
        /// </summary>
        /// <param name="id">Id of the engineer to remove</param>
        void Remove(int id);

        /// <summary>
        /// Retrieves an engineer from the repository
        /// </summary>
        /// <param name="id">Id of the engineer to retreive</param>
        /// <returns></returns>
        EngineerModel Find(int id);
    }
}
