using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using UnityWcfPerrequestLifetimeManager.Extensions;

namespace UnityWcfPerrequestLifetimeManager.Managers
{
    public class PerRequestLifetimeManager : WcfLifetimeManager<OperationContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PerRequestLifetimeManager"/> class.
        /// </summary>
        public PerRequestLifetimeManager()
            : base()
        {
        }

        /// <summary>
        /// Returns the appropriate extension for the current lifetime manager.
        /// </summary>
        /// <returns>The registered extension for the current lifetime manager, otherwise, null if the extension is not registered.</returns>
        //protected override UnityWcfExtension<OperationContext> FindExtension()
        protected override UnityWcfExtension<OperationContext> FindExtension()
        {
            return PerRequestLifetimeExtension.Current;
        }
    }
}