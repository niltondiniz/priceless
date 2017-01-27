using System;
using SQLite.Net.Interop;

namespace Priceless
{
	public interface IConfig
	{
		string DiretorioDB { get; }
		ISQLitePlatform Plataforma { get; }

	}
}
