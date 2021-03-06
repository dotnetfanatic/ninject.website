#region License
// 
// Author: Nate Kohari <nate@enkari.com>
// Copyright (c) 2009, Enkari, Ltd.
// 
// Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// See the file LICENSE.txt for details.
// 
#endregion
#region Using Directives
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Ninject.Website.Data;
using Ninject.Website.Data.Collections;
#endregion

namespace Ninject.Website.Services.Persistence
{
	public class XmlProductRepository : IRepository<Product>
	{
		private const string RelativePath = "~/data/products.xml";

		public string Filename { get; private set; }
		public XmlLoader Loader { get; private set; }

		public XmlProductRepository(HttpContextBase httpContext, XmlLoader loader)
		{
			Filename = httpContext.Server.MapPath(RelativePath);
			Loader = loader;
		}

		public IQueryable<Product> GetAll()
		{
			return Loader.Load<ProductCollection>(Filename).AsQueryable();
		}
	}
}