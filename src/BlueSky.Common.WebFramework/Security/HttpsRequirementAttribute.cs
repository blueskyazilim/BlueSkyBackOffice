namespace BlueSky.Common.WebFramework.Security
{
    using Core.DesignByContract;
    using System;
    using System.Web.Mvc;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited =true,AllowMultiple =false)]
    public class HttpsRequirementAttribute : 
        FilterAttribute,
        IAuthorizationFilter
    {
        public HttpsRequirementAttribute(SslRequirement sslRequirement)
        {
            this.SslRequirement = sslRequirement;
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            Require.That(filterContext, Is.NotNull);

            if (filterContext.IsChildAction)
            {
                return;
            }


        }

        public SslRequirement SslRequirement { get; private set; }
    }
}
