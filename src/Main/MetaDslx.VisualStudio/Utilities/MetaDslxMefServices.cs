using Microsoft.VisualStudio.ComponentModelHost;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Utilities
{
    [Export]
    public sealed class MetaDslxMefServices
    {
        [ImportingConstructor]
        public MetaDslxMefServices([Import(typeof(SVsServiceProvider))] IServiceProvider site)
        {
            ServiceProvider = site;
            _componentModel = new Lazy<IComponentModel>(site.GetComponentModel, true);
            _contentTypeRegistry = new Lazy<IContentTypeRegistryService>(() => this.ComponentModel.GetService<IContentTypeRegistryService>(), true);
        }

        public readonly IServiceProvider ServiceProvider;

        private readonly Lazy<IComponentModel> _componentModel;
        private readonly Lazy<IContentTypeRegistryService> _contentTypeRegistry;

        public IComponentModel ComponentModel => _componentModel.Value;
        public IContentTypeRegistryService ContentTypeRegistry => _contentTypeRegistry.Value;

        public T GetService<T>()
            where T : class
        {
            return this.ComponentModel.GetService<T>();
        }

        public T GetService<T>(string contentTypeName, bool inherited = true)
            where T : class
        {
            var contentType = this.ContentTypeRegistry.GetContentType(contentTypeName);
            return this.GetService<T>(contentType, inherited);
        }

        public T GetService<T>(IContentType contentType, bool inherited = true)
            where T : class
        {
            return this.GetExtensions<T>(contentType, inherited).SingleOrDefault();
        }

        public IEnumerable<T> GetExtensions<T>()
            where T : class
        {
            return this.ComponentModel.GetExtensions<T>();
        }

        public IEnumerable<T> GetExtensions<T>(string contentTypeName, bool inherited = true)
            where T : class
        {
            var contentType = this.ContentTypeRegistry.GetContentType(contentTypeName);
            return this.GetExtensions<T>(contentType, inherited);
        }

        public IEnumerable<T> GetExtensions<T>(IContentType contentType, bool inherited = true)
            where T : class
        {
            var extensions = this.ComponentModel.GetExtensions<T>().ToList();
            foreach (var ext in extensions)
            {
                var contentTypeAttributes = (ContentTypeAttribute[])ext.GetType().GetCustomAttributes(typeof(ContentTypeAttribute), false);
                foreach (var cta in contentTypeAttributes)
                {
                    var extContentType = this.ContentTypeRegistry.GetContentType(cta.ContentTypes);
                    if (extContentType == contentType || (inherited && contentType.BaseTypes.Contains(extContentType)))
                    {
                        yield return ext;
                    }
                }
            }
            //var extensionsOfContentType = extensions.Where(ext => ext.GetType().GetCustomAttributes(typeof(ContentTypeAttribute), true).Cast<ContentTypeAttribute>().Any(cta => cta.ContentTypes == contentType.TypeName)).ToList();
            //return extensionsOfContentType;
        }
    }
}
