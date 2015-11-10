#region Copyright (C) 2015 Oren Fromberg

//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see http://www.gnu.org/licenses/.
//
//  This code is heavily based on stravadotnet: https://github.com/inexcitus/stravadotnet
//  Copyright (C) Sascha Simon 2014 and Licensed under GPL v3.
//  Visit the official homepage at http://www.sascha-simon.com

#endregion

using System;
using com.sefaria.api.Authentication;

namespace com.sefaria.api.Clients
{
	public class BaseClient
	{
		protected IAuthentication Authentication;

		public BaseClient(IAuthentication authentication)
		{
			if (authentication == null)
			{
				throw new ArgumentException("The IAuthentication Object must not be null.");
			}

			Authentication = authentication;
		}
	}
}