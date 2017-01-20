using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Web_Api_Rest
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DatabaseApi",
				routeTemplate: "api/Database/{database}",
				defaults: new { controller = "Database", database = RouteParameter.Optional }
			);
			config.Routes.MapHttpRoute(
				name: "TableApi",
				routeTemplate: "api/Database/{database}/Table/{table}",
				defaults: new { controller = "Table", table = RouteParameter.Optional }
			);
			config.Routes.MapHttpRoute(
				name: "DistinctApi",
				routeTemplate: "api/Database/{database}/Table/{table}/Distinct",
				defaults: new { controller = "Distinct", action = "Distinct" }
			);
			config.Routes.MapHttpRoute(
				name: "ColumnApi",
				routeTemplate: "api/Database/{database}/Table/{table}/Column/{column}",
				defaults: new { controller = "Column", column = RouteParameter.Optional }
			);
			config.Routes.MapHttpRoute(
				name: "RowApi",
				routeTemplate: "api/Database/{database}/Table/{table}/Column/{column}/Row/{row}",
				defaults: new { controller = "Row" }
			);
			config.Routes.MapHttpRoute(
				name: "RowExtApi",
				routeTemplate: "api/Database/{database}/Table/{table}/Row/{row}",
				defaults: new { controller = "Row" }
			);
		}
	}
}
