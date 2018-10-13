using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace UnityWcfPerrequestLifetimeManager.Extensions
{
    internal class PerRequestLifetimeExtension : UnityWcfExtension<OperationContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnityOperationContextExtension"/> class.
        /// </summary>
        public PerRequestLifetimeExtension()
            : base()
        {
        }

        /// <summary>
        /// Gets the <see cref="UnityOperationContextExtension"/> for the current operation context.
        /// </summary>
        public static PerRequestLifetimeExtension Current
        {
            get
            {
                PerRequestLifetimeExtension context = OperationContext.Current.Extensions.Find<PerRequestLifetimeExtension>();
                if (context == null)
                {
                    context = new PerRequestLifetimeExtension();
                    OperationContext.Current.Extensions.Add(context);
                }

                return context;
            }
        }
    }
}