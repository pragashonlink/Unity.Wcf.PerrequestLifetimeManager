using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Unity.Lifetime;
using UnityWcfPerrequestLifetimeManager.Extensions;

namespace UnityWcfPerrequestLifetimeManager.Managers
{
    public abstract class WcfLifetimeManager<T> : LifetimeManager
        where T : IExtensibleObject<T>
    {
        private Guid key = Guid.NewGuid();

        protected WcfLifetimeManager()
            : base()
        {
        }

        private UnityWcfExtension<T> Extension
        {
            get
            {
                UnityWcfExtension<T> extension = this.FindExtension();
                if (extension == null)
                {
                    throw new InvalidOperationException(
                        string.Format(CultureInfo.CurrentCulture, "UnityWcfExtension<{0}> must be registered in WCF.", typeof(T).Name));
                }

                return extension;
            }
        }

        public override object GetValue(ILifetimeContainer container = null)
        {
            return this.Extension.FindInstance(this.key);
        }

        public override void SetValue(object newValue, ILifetimeContainer container = null)
        {
            this.Extension.RegisterInstance(this.key, newValue);
        }

        public override void RemoveValue(ILifetimeContainer container = null)
        {
            this.Extension.RemoveInstance(this.key);
        }

        protected override LifetimeManager OnCreateLifetimeManager()
        {
            throw new NotImplementedException();
        }

        protected abstract UnityWcfExtension<T> FindExtension();
    }
}