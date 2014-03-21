using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using CabFinderDomain;
using Ninject;

namespace CabFinderWebAPI.App_Start
{
    public class DependencyResolver : NinjectScope, IDependencyResolver
        {
            private IKernel _kernel;

            public DependencyResolver(IKernel kernel)
                : base(kernel)
            {
                _kernel = kernel;
            }

            public IDependencyScope BeginScope()
            {
                return new NinjectScope(_kernel.BeginBlock());
            }
        }
}