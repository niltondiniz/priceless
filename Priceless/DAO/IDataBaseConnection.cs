using System;
namespace Priceless
{
	public interface IDataBaseConnection
	{
		SQLite.Net.SQLiteConnection DBConnection();
	}
}
