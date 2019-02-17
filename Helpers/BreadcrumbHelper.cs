using System;
using System.Text;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Routing;

namespace SimpleBlog.FrontEnd.Helpers
{
    public static class BreadcrumbHelper
    {
        public static string Tag(string id, object data)
        {
            if (data is null)
            {
                return null;
            }

            var routeData = data as RouteData;
            var breadcrumbInner = new StringBuilder();

            var routePath = new List<string>();
            var routeIndex = 0;

            foreach (var r in routeData.Values.Values)
            {
                routeIndex++;
                var route = r.ToString();

                if (route.Equals("Index", StringComparison.Ordinal)
                    || route.Equals("Details", StringComparison.Ordinal))
                {
                    continue;
                }

                if (int.TryParse(route, out _))
                {
                    continue;
                }

                if (route.Contains("-"))
                {
                    route = route.Replace("-", " ");
                }

                routePath.Add(route);

                if (routeIndex < routeData.Values.Values.Count())
                {
                    breadcrumbInner.AppendFormat(@"&gt; <a href='/{0}'>{1}</a> ",
                                           string.Join('/', routePath.ToArray()),
                                           r);
                }
                else
                {
                    breadcrumbInner.AppendFormat(@"&gt; <span>{0}</span>", route);
                }
            }

            var builder = new TagBuilder("div");
            builder.GenerateId(id);
            builder.InnerHtml = breadcrumbInner.ToString();

            return builder.ToString();
        }
    }
}
