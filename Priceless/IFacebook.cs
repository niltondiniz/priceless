using System;
using System.Threading.Tasks;

namespace Priceless
{
	public interface IFacebook
	{
		bool Logoff();
		bool Login();
	}
}
